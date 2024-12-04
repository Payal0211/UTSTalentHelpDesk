using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Models.ViewModels;

namespace UTSTalentHelpDesk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public TicketsController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        // OAuth Callback to Exchange Authorization Code for Access and Refresh Tokens
        [HttpGet("callback")]
        public async Task<IActionResult> OAuthCallback([FromQuery] string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Authorization code is missing.");
            }

            var zohoConfig = _configuration.GetSection("Zoho");
            string tokenEndpoint = zohoConfig["TokenEndpoint"];
            string clientId = zohoConfig["ClientId"];
            string clientSecret = zohoConfig["ClientSecret"];
            string redirectUri = zohoConfig["RedirectUri"];

            var payload = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
                new KeyValuePair<string, string>("code", code)
            });

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync(tokenEndpoint, payload);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());
                await SaveTokensToDatabase("ZohoAccessToken", tokenResponse.AccessToken, tokenResponse.RefreshToken);

                return Ok(new { message = "Tokens saved successfully!", tokenResponse });
            }

            var error = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, error);
        }

        // Create a Ticket
        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketRequest request)
        {
            string accessToken = await GetAccessTokenAsync();

            if (string.IsNullOrEmpty(accessToken))
            {
                return StatusCode(500, "Failed to generate access token.");
            }

            var zohoConfig = _configuration.GetSection("Zoho");
            var baseUrl = zohoConfig["BaseUrl"];
            var url = $"{baseUrl}/tickets";

            var payload = new
            {
                subject = request.Subject,
                departmentId = request.DepartmentId,
                description = request.Description,
                email = request.Email
            };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return Ok(JsonConvert.DeserializeObject(result));
            }

            var error = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, error);
        }

        // Retrieve Access Token, Refresh if Expired
        private async Task<string> GetAccessTokenAsync()
        {
            string refreshToken = await GetTokenFromDatabase("ZohoAccessToken", "RefreshToken");
            string accessToken = await GetTokenFromDatabase("ZohoAccessToken", "AccessToken");

            if (!string.IsNullOrEmpty(accessToken))
            {
                return accessToken;
            }

            if (string.IsNullOrEmpty(refreshToken))
            {
                throw new Exception("Refresh token is missing. Re-authentication is required.");
            }

            // Refresh the access token
            var zohoConfig = _configuration.GetSection("Zoho");
            string clientId = zohoConfig["ClientId"];
            string clientSecret = zohoConfig["ClientSecret"];
            string tokenEndpoint = zohoConfig["TokenEndpoint"];

            var payload = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("refresh_token", refreshToken),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("grant_type", "refresh_token")
            });

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync(tokenEndpoint, payload);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());
                await UpdateTokenInDatabase("ZohoAccessToken", tokenResponse.AccessToken);
                return tokenResponse.AccessToken;
            }

            return null;
        }

        // Save Tokens to the Database
        private async Task SaveTokensToDatabase(string tokenName, string accessToken, string refreshToken)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_SaveTokens", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TokenName", tokenName);
                    command.Parameters.AddWithValue("@AccessToken", accessToken);
                    command.Parameters.AddWithValue("@RefreshToken", refreshToken);
                    command.Parameters.AddWithValue("@LastUpdated", DateTime.UtcNow);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Get Token from the Database
        private async Task<string> GetTokenFromDatabase(string tokenName, string column)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_GetToken", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TokenName", tokenName);
                    command.Parameters.AddWithValue("@Column", column);

                    connection.Open();
                    var result = await command.ExecuteScalarAsync();
                    return result?.ToString();
                }
            }
        }

        // Update Access Token in the Database
        private async Task UpdateTokenInDatabase(string tokenName, string newAccessToken)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_UpdateToken", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TokenName", tokenName);
                    command.Parameters.AddWithValue("@TokenValue", newAccessToken);
                    command.Parameters.AddWithValue("@LastUpdated", DateTime.UtcNow);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
