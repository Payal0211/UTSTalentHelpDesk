using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Models.ViewModels;
using UTSTalentHelpDesk.Repositories.Interfaces;
using UTSTalentHelpDesk.Repositories.Repositories;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using static UTSTalentHelpDesk.Config.HubSpotResponseUTSAdmin;

namespace UTSTalentHelpDesk.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Tickets/", Name = "Ticket")]
    public class TicketsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfigurationSection zohoConfig;
        private readonly ITicket _iTicket;
        private readonly HttpClient _httpClient;

        public TicketsController(IConfiguration configuration, IHttpClientFactory httpClientFactory, ITicket iTicket, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            zohoConfig = _configuration.GetSection("Zoho");
            _iTicket = iTicket;
            _httpClient = httpClient;
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

                TS_sproc_GetToken_Result companyListData = await _iTicket.GetTokenList(paramasString).ConfigureAwait(false);
                return companyListData.Column.ToString();
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
        #region Commented Code
        // Create a Ticket
        //[HttpPost("create")]
        //public async Task<IActionResult> CreateTicket([FromBody] TicketRequest request)
        //{
        //    try
        //    {
        //        string accessToken = await GetAccessTokenAsync();

        //        if (string.IsNullOrEmpty(accessToken))
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseObject() { statusCode = StatusCodes.Status500InternalServerError, Message = "Failed to generate access token." });
        //        }

        //        //var zohoConfig = _configuration.GetSection("Zoho");
        //        var baseUrl = zohoConfig["BaseUrl"];
        //        var url = $"{baseUrl}/tickets";

        //        var payload = new
        //        {
        //            subject = request.Subject,
        //            departmentId = request.DepartmentId,
        //            description = request.Description,
        //            email = request.Email
        //        };

        //        var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

        //        var client = _httpClientFactory.CreateClient();
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

        //        var response = await client.PostAsync(url, content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();
        //            var ticketResponse = JsonConvert.DeserializeObject<ZohoTicketResponse>(result);

        //            // Call stored procedure to save ticket in the local database
        //            await SaveTicketToDatabaseAsync(ticketResponse.TicketNumber, request.Subject, request.Description, request.Email);

        //            return StatusCode(StatusCodes.Status200OK, new ResponseObject()
        //            {
        //                statusCode = StatusCodes.Status200OK,
        //                Message = "Ticket Created Successfully.",
        //                Details = ticketResponse
        //            });
        //        }

        //        var error = await response.Content.ReadAsStringAsync();
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = error });
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //private async Task SaveTicketToDatabaseAsync(string ticketNumber, string subject, string description, string email)
        //{
        //    try
        //    {
        //        object[] param = new object[] {
        //            ticketNumber,
        //            subject,
        //            description,
        //            email
        //        };

        //        string paramasString = CommonLogic.ConvertToParamString(param);

        //        _iTicket.SaveTickets(paramasString);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //        // Log the exception (if required)
        //        //throw new Exception($"Error saving ticket to database: {ex.Message}", ex);
        //    }
        //}

        // Create a Ticket
        #endregion

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateTicketAsync(ZohoTicketRequest request)
        {
            string accessToken = await GetAccessTokenAsync();

            if (string.IsNullOrEmpty(accessToken))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseObject() { statusCode = StatusCodes.Status500InternalServerError, Message = "Failed to generate access token." });
            }

            // Configure Zoho API headers
            _httpClient.DefaultRequestHeaders.Add("orgId", _configuration["Zoho:OrgId"]);
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Authorization", $"Zoho-oauthtoken {accessToken}");

            // Create ticket in Zoho
            var response = await _httpClient.PostAsJsonAsync(
                "https://desk.zoho.com/api/v1/tickets",
                request
            );

            response.EnsureSuccessStatusCode();

            var ticketResponse = await response.Content.ReadFromJsonAsync<ZohoTicketResponse>();

            // Save ticket response to database
            //SaveTicketResponseAsync(ticketResponse);
            try
            {
                object[] param = new object[] {
                    ticketResponse.Id,
                    ticketResponse.TicketNumber,
                    ticketResponse.Subject,
                    ticketResponse.Status,
                    ticketResponse.StatusType,
                    ticketResponse.Priority,
                    ticketResponse.Category,
                    ticketResponse.SubCategory,
                    // Dates
                    ticketResponse.CreatedTime,
                    ticketResponse.ModifiedTime,
                    ticketResponse.DueDate,
                    ticketResponse.ClosedTime,
                    ticketResponse.CustomerResponseTime,
                    // Contact and Communication Details
                    ticketResponse.Email,
                    ticketResponse.Phone,
                    ticketResponse.ContactId,
                    ticketResponse.AssigneeId,
                    ticketResponse.DepartmentId,
                    // Descriptive Fields
                    ticketResponse.Description,
                    ticketResponse.Language,
                    ticketResponse.Channel,
                    ticketResponse.WebUrl,
                    // Flags and Status Indicators
                    ticketResponse.IsOverDue,
                    ticketResponse.IsDeleted,
                    ticketResponse.IsTrashed,
                    ticketResponse.IsEscalated,
                    ticketResponse.IsSpam,
                    // Counts
                    ticketResponse.SharedCount,
                    ticketResponse.ApprovalCount,
                    ticketResponse.TimeEntryCount,
                    ticketResponse.ThreadCount,
                    ticketResponse.CommentCount,
                    ticketResponse.TaskCount,
                    ticketResponse.AttachmentCount,
                    // Custom Fields
                    ticketResponse.Cf?.Cf_PermanentAddress,
                    ticketResponse.Cf?.Cf_DateOfPurchase,
                    ticketResponse.Cf?.Cf_Phone,
                    ticketResponse.Cf?.Cf_NumberOfItems,
                    ticketResponse.Cf?.Cf_Url,
                    ticketResponse.Cf?.Cf_SecondaryEmail,
                    ticketResponse.Cf?.Cf_SeverityPercentage,
                    ticketResponse.Cf?.Cf_ModelName,
                    // Entity Skills (serialized)
                    ticketResponse.EntitySkills != null ? string.Join(",", ticketResponse.EntitySkills) : null,
                    // Source Info (serialized)
                    ticketResponse.Source?.Type,
                    ticketResponse.Source?.AppName,
                    ticketResponse.Source?.ExtId,
                    ticketResponse.Source?.Permalink,
                    ticketResponse.Source?.AppPhotoURL
                };

                string paramasString = CommonLogic.ConvertToParamString(param);

                _iTicket.SaveTickets(paramasString);
            }
            catch (Exception)
            {

                throw;
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Ticket Created.",Details = ticketResponse });
            //return ticketResponse;

        }

        //private async Task SaveTicketResponseAsync(ZohoTicketResponse ticketResponse)
        //{
            

        //}
        #endregion

        #region Save All Tickets into db from Zoho
        [HttpPost("SaveTickets")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveTickets([FromBody] TicketResponse ticketResponse)
        {
            try
            {
                if (ticketResponse?.Data == null || !ticketResponse.Data.Any())
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Invalid Payload." });

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

        #region When New Ticket Create in Zoho it will call below API through webhook
        [HttpPost("SaveToZohoTicket")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveToZohoTicket([FromBody] ZohoWebhookPayload webhookPayload)
        {
            try
            {
                if (webhookPayload?.Payload == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Invalid Payload." });

                var payload = webhookPayload.Payload;

                object[] param = new object[] {
                // Ticket Main Details
                payload.Id,
                payload.TicketNumber,
                payload.Subject,
                payload.Description,
                payload.Status,
                payload.StatusType,
                payload.Priority ?? string.Empty,
                payload.Category,
                payload.SubCategory ?? string.Empty,
                // Channel Information
                payload.Channel,
                payload.ChannelCode ?? string.Empty,
                payload.Source?.Type ?? string.Empty,
                payload.Source?.AppName ?? string.Empty,
                // Contact Details
                payload.ContactId,
                payload.Contact?.FirstName ?? string.Empty,
                payload.Contact?.LastName ?? string.Empty,
                payload.Contact?.Email ?? string.Empty,
                payload.Contact?.Phone ?? string.Empty,
                payload.Contact?.Mobile ?? string.Empty,
                // Assignee Details
                payload.AssigneeId,
                payload.Assignee?.FirstName ?? string.Empty,
                payload.Assignee?.LastName ?? string.Empty,
                payload.Assignee?.Email ?? string.Empty,
                // Ticket Flags
                payload.IsOverDue,
                payload.IsTrashed,
                payload.IsResponseOverDue,
                payload.IsSpam,
                payload.IsArchived,
                payload.IsDeleted,
                payload.IsEscalated,
                // Dates and Times
                payload.CreatedTime,
                payload.ModifiedTime,
                payload.DueDate,
                payload.ClosedTime,
                payload.CustomerResponseTime,
                payload.ResponseDueDate,
                payload.LastActivityTime,
                // Counts
                int.Parse(payload.ThreadCount ?? "0"),
                int.Parse(payload.CommentCount ?? "0"),
                int.Parse(payload.TaskCount ?? "0"),
                int.Parse(payload.ApprovalCount ?? "0"),
                int.Parse(payload.AttachmentCount ?? "0"),
                // Additional Details
                payload.DepartmentId ?? string.Empty,
                payload.TeamId ?? string.Empty,
                payload.ProductId ?? string.Empty,
                payload.AccountId ?? string.Empty,
                payload.LayoutDetails?.Id ?? string.Empty,
                payload.LayoutDetails?.LayoutName ?? string.Empty,
                // Custom Fields                
                decimal.TryParse(payload.CustomField?.SeverityPercentage ?? "0", out decimal severity) ? severity : 0,
                payload.CustomField?.DateOfPurchase,
                payload.CustomField?.Url ?? string.Empty,
                // Webhook Details
                webhookPayload.EventTime,
                webhookPayload.EventType,
                webhookPayload.OrgId
            };

                string paramasString = CommonLogic.ConvertToParamString(param);

                _iTicket.SaveZohoTickets(paramasString);
                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Ticket saved." });
            }
            catch (Exception ex)
            {
                // Log the exception
                //_logger.LogError(ex, "Error saving Zoho ticket");
                throw;
            }
        }
        #endregion

        #region When Ticket Update in Zoho it will call below API through webhook
        [HttpPost("UpdateZohoTicket")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateZohoTicket([FromBody] ZohoWebhookPayload webhookPayload)
        {
            try
            {
                // Validate the payload
                if (webhookPayload?.Payload == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Invalid Payload." });
                }

                var payload = webhookPayload.Payload;

                object[] param = new object[] {
                    // Ticket Main Details
                    payload.Id,
                    payload.TicketNumber,
                    payload.Subject,
                    payload.Description,
                    payload.Status,
                    payload.StatusType,
                    payload.Priority ?? string.Empty,
                    payload.Category,
                    payload.SubCategory ?? string.Empty,
                    // Channel Information
                    payload.Channel,
                    payload.ChannelCode ?? string.Empty,
                    payload.Source?.Type ?? string.Empty,
                    payload.Source?.AppName ?? string.Empty,
                    // Contact Details
                    payload.ContactId,
                    payload.Contact?.FirstName ?? string.Empty,
                    payload.Contact?.LastName ?? string.Empty,
                    payload.Contact?.Email ?? string.Empty,
                    payload.Contact?.Phone ?? string.Empty,
                    payload.Contact?.Mobile ?? string.Empty,
                    // Assignee Details
                    payload.AssigneeId,
                    payload.Assignee?.FirstName ?? string.Empty,
                    payload.Assignee?.LastName ?? string.Empty,
                    payload.Assignee?.Email ?? string.Empty,
                    // Ticket Flags
                    payload.IsOverDue,
                    payload.IsTrashed,
                    payload.IsResponseOverDue,
                    payload.IsSpam,
                    payload.IsArchived,
                    payload.IsDeleted,
                    payload.IsEscalated,
                    // Dates and Times
                    payload.CreatedTime,
                    payload.ModifiedTime,
                    payload.DueDate,
                    payload.ClosedTime,
                    payload.CustomerResponseTime,
                    payload.ResponseDueDate,
                    payload.LastActivityTime,
                    // Counts
                    int.Parse(payload.ThreadCount ?? "0"),
                    int.Parse(payload.CommentCount ?? "0"),
                    int.Parse(payload.TaskCount ?? "0"),
                    int.Parse(payload.ApprovalCount ?? "0"),
                    int.Parse(payload.AttachmentCount ?? "0"),
                    // Additional Details
                    payload.DepartmentId ?? string.Empty,
                    payload.TeamId ?? string.Empty,
                    payload.ProductId ?? string.Empty,
                    payload.AccountId ?? string.Empty,
                    payload.LayoutDetails?.Id ?? string.Empty,
                    payload.LayoutDetails?.LayoutName ?? string.Empty,
                    // Custom Fields                
                    decimal.TryParse(payload.CustomField?.SeverityPercentage ?? "0", out decimal severity)
                        ? severity : 0,
                    payload.CustomField?.DateOfPurchase,
                    payload.CustomField?.Url ?? string.Empty,
                    // Webhook Details
                    webhookPayload.EventTime,
                    webhookPayload.EventType,
                    webhookPayload.OrgId
                };
                string paramasString = CommonLogic.ConvertToParamString(param);

                // Call update method
                _iTicket.SaveZohoTickets(paramasString);
                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Ticket Updated." });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region delete ticket in zoho webhook
        [HttpPost("DeleteZohoTicket")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteZohoTicket([FromBody] ZohoWebhookDeleteTicket webhookPayload)
        {
            try
            {
                // Validate the payload
                if (webhookPayload?.Payload == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Invalid Payload." });
                }

                var payload = webhookPayload.Payload;

                object[] param = new object[] {
                    // Ticket Main Details
                    payload.Id,                    
                    // Webhook Details
                    webhookPayload.EventTime,
                    webhookPayload.EventType,
                    webhookPayload.OrgId
                };
                string paramasString = CommonLogic.ConvertToParamString(param);

                // Call update method
                _iTicket.deleteZohoTickets(paramasString);
                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Ticket Updated." });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Save tickets from zoho api in one go
        [HttpPost("SaveZohoTicketinOneGo")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveZohoTicketinOneGo([FromBody] List<ZohoTicketsRequest> webhookPayload)
        {
            try
            {
                if (webhookPayload == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Invalid Payload." });

                foreach (var payload in webhookPayload) 
                {
                    object[] param = new object[]
                    {
                    payload.id,
                    payload.ticketNumber,
                    payload.subject,
                    "",
                    payload.status,
                    payload.statusType,
                    payload.priority,
                    payload.category,
                    payload.subCategory,
                    payload.createdTime,
                    payload.dueDate,
                    payload.closedTime,
                    payload.customerResponseTime,                    
                    payload.email,
                    payload.phone,
                    payload.contactId,
                    payload.assigneeId,
                    payload.departmentId,
                    payload.channel,
                    payload.webUrl,
                    payload.isSpam,
                    payload.isArchived
                    };

                    string paramasString = CommonLogic.ConvertToParamStringWithNull(param);

                    _iTicket.SaveZohoTickets(paramasString);
                }
                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Ticket saved." });
            }
            catch (Exception ex)
            {  
                throw ex;
            }
        }
        #endregion
    }
}
