using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Models.ViewModels;
using UTSTalentHelpDesk.Repositories.Interfaces;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace UTSTalentHelpDesk.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfigurationSection zohoConfig;
        private readonly ITicket _iTicket;

        public TicketsController(IConfiguration configuration, IHttpClientFactory httpClientFactory, ITicket iTicket)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            zohoConfig = _configuration.GetSection("Zoho");
            _iTicket = iTicket;
        }

        #region Token Generation
        // OAuth Callback to Exchange Authorization Code for Access and Refresh Tokens
        [HttpGet("callback")]
        [AllowAnonymous]
        public async Task<IActionResult> OAuthCallback([FromQuery] string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    //return BadRequest("Authorization code is missing.");
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Authorization code is missing." });
                }

                //var zohoConfig = _configuration.GetSection("Zoho");
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
                    if (tokenResponse != null)
                    {
                        await SaveTokensToDatabase("ZohoAccessToken", tokenResponse.AccessToken, tokenResponse.RefreshToken);
                        //return Ok(new { message = "Tokens saved successfully!", tokenResponse });
                        return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Tokens saved successfully!", Details = tokenResponse });
                    }
                }

                var error = await response.Content.ReadAsStringAsync();
                //return StatusCode((int)response.StatusCode, error);
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = error });

            }
            catch (Exception)
            {

                throw;
            }
        }

        // Retrieve Access Token, Refresh if Expired
        private async Task<string> GetAccessTokenAsync()
        {
            try
            {
                string refreshToken = await GetTokenFromDatabase("ZohoAccessToken", "RefreshToken");
                string accessToken = await GetTokenFromDatabase("ZohoAccessToken", "AccessToken");

                if (!string.IsNullOrEmpty(accessToken))
                {
                    return accessToken;
                }

                if (string.IsNullOrEmpty(refreshToken))
                {
                    //throw new Exception("Refresh token is missing. Re-authentication is required.");
                    return null;
                }

                // Refresh the access token
                //var zohoConfig = _configuration.GetSection("Zoho");
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
            catch (Exception)
            {

                throw;
            }
        }

        // Save Tokens to the Database
        private async Task SaveTokensToDatabase(string tokenName, string accessToken, string refreshToken)
        {
            try
            {
                object[] param = new object[] {
                tokenName,accessToken,refreshToken};

                string paramasString = CommonLogic.ConvertToParamString(param);

                _iTicket.CreateTicket(paramasString);

            }
            catch (Exception)
            {

                throw;
            }

        }

        // Get Token from the Database
        private async Task<string> GetTokenFromDatabase(string tokenName, string column)
        {
            try
            {
                object[] param = new object[] {
                tokenName,column};

                string paramasString = CommonLogic.ConvertToParamString(param);

                sp_GetToken_Result companyListData = await _iTicket.GetTokenList(paramasString).ConfigureAwait(false);
                return companyListData.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Update Access Token in the Database
        private async Task UpdateTokenInDatabase(string tokenName, string newAccessToken)
        {
            try
            {
                object[] param = new object[] {
                tokenName,newAccessToken};

                string paramasString = CommonLogic.ConvertToParamString(param);

                _iTicket.UpdateTicket(paramasString);

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion

        #region Create New Ticket in Zoho
        // Create a Ticket
        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketRequest request)
        {
            try
            {
                string accessToken = await GetAccessTokenAsync();

                if (string.IsNullOrEmpty(accessToken))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseObject() { statusCode = StatusCodes.Status500InternalServerError, Message = "Failed to generate access token." });
                }

                //var zohoConfig = _configuration.GetSection("Zoho");
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
                    var ticketResponse = JsonConvert.DeserializeObject<ZohoTicketResponse>(result);

                    // Call stored procedure to save ticket in the local database
                    await SaveTicketToDatabaseAsync(ticketResponse.TicketNumber, request.Subject, request.Description, request.Email);

                    return StatusCode(StatusCodes.Status200OK, new ResponseObject()
                    {
                        statusCode = StatusCodes.Status200OK,
                        Message = "Ticket Created Successfully.",
                        Details = ticketResponse
                    });
                }

                var error = await response.Content.ReadAsStringAsync();
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = error });
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task SaveTicketToDatabaseAsync(string ticketNumber, string subject, string description, string email)
        {
            try
            {
                object[] param = new object[] {
                    ticketNumber,
                    subject,
                    description,
                    email
                };

                string paramasString = CommonLogic.ConvertToParamString(param);

                _iTicket.SaveTickets(paramasString);
            }
            catch (Exception ex)
            {
                throw;
                // Log the exception (if required)
                //throw new Exception($"Error saving ticket to database: {ex.Message}", ex);
            }
        }
        #endregion


        #region Save All Tickets into db from Zoho
        [HttpPost("SaveTickets")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveTickets([FromBody] TicketResponse ticketResponse)
        {
            try
            {
                if (ticketResponse?.Data == null || !ticketResponse.Data.Any())
                    return BadRequest("Invalid data");

                foreach (var ticket in ticketResponse.Data)
                {
                    object[] param = new object[] {
                    ticket.TicketNumber,
                    ticket.SubCategory,
                    ticket.Subject,
                    ticket.DueDate,
                    ticket.DepartmentId,
                    ticket.Channel,
                    ticket.OnholdTime,
                    ticket.Source?.Type,
                    ticket.ClosedTime,
                    ticket.SharedCount,
                    ticket.ResponseDueDate,
                    ticket.Contact?.FirstName,
                    ticket.Contact?.LastName,
                    ticket.Contact?.Phone,
                    ticket.Contact?.Mobile,
                    ticket.Contact?.Id,
                    ticket.Contact?.Email,
                    ticket.Contact?.Account?.AccountName,
                    ticket.Contact?.Account?.Id,
                    ticket.CreatedTime,
                    ticket.Id,
                    ticket.Email,
                    ticket.ChannelCode,
                    ticket.CustomerResponseTime,
                    ticket.Priority,
                    ticket.Assignee?.FirstName,
                    ticket.Assignee?.LastName,
                    ticket.Assignee?.Email,
                    ticket.Status
                };

                    string paramasString = CommonLogic.ConvertToParamString(param);

                    _iTicket.SaveAllTickets(paramasString);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "All Tickets saved." });
        }
        #endregion

    }
}
