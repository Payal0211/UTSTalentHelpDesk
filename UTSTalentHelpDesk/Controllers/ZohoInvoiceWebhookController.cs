using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Models.ViewModels;
using UTSTalentHelpDesk.Repositories.Interfaces;
using static Google.Apis.Requests.BatchRequest;
using static UTSTalentHelpDesk.Config.HubSpotResponseUTSAdmin;

namespace UTSTalentHelpDesk.Controllers
{
    [Route("ZohoInvoice/", Name = "ZohoInvoice")]
    [ApiController]
    public class ZohoInvoiceWebhookController : ControllerBase
    {
        private readonly IConfiguration _iConfiguration;             
        private readonly IZohoInvoice _iZohoInvoice;
        private readonly HttpClient _httpClient;
        private readonly ITicket _iTicket;


        public ZohoInvoiceWebhookController(IConfiguration configuration, 
                IZohoInvoice iZohoInvoice, HttpClient httpClient, ITicket iTicket)
        {
            _iConfiguration = configuration;            
            _iZohoInvoice = iZohoInvoice;
            _httpClient = httpClient;
            _iTicket = iTicket;
           
        }       

        [HttpPost("ZohoCustomersInsertInOneGo")]
        public async Task ZohoCustomersInsertInOneGo(ZohoContactsViewModel contactsData)
        {
            if (contactsData != null)
            {
                long zohoOrganizationID = Convert.ToInt64(_iConfiguration["ZohoInvoiceOrgID"]);
                foreach (var contact in contactsData.contacts)
                {
                    long customerId = Convert.ToInt64(contact.contact_id);
                    // Save each customer in DB.
                    object[] param = new object[] {

                        zohoOrganizationID,
                        contact.contact_id,
                        contact.customer_name,
                        contact.vendor_name,
                        contact.company_name,
                        null,
                        contact.first_name,
                        contact.last_name,
                        contact.email,
                        contact.phone,
                        contact.mobile,
                        null,
                        contact.facebook,
                        contact.twitter,
                        null,
                        null,
                        null,
                        null,
                        contact.payment_terms,
                        contact.payment_terms_label,
                        contact.currency_code,
                        null,
                        contact.website,
                        contact.contact_type,
                        contact.customer_sub_type,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        contact.source,
                        null,
                        null,
                        contact.status,
                        null,
                        null,
                        true,
                        null,
                        Convert.ToInt64(contact.currency_id)
                    };
                    string paramString = CommonLogic.ConvertToParamStringWithNull(param);
                    await _iZohoInvoice.InsertUpdateZohoCustomers(paramString);

                    // Get contact person from customer ID
                    string contactPersonResponse = await FetchContactPersonFromCustomerID(customerId, zohoOrganizationID);
                    if (!string.IsNullOrEmpty(contactPersonResponse))
                    {
                        ZohoContactPersonViewModel? zohoContactPerson = JsonConvert.DeserializeObject<ZohoContactPersonViewModel>(contactPersonResponse);
                        if (zohoContactPerson != null)
                        {
                            foreach(var contactPerson in zohoContactPerson.contact_persons)
                            {
                                // save each contactperson in table
                                object[] contactParam = new object[]
                                {
                                    contact.contact_id,
                                    contactPerson.contact_person_id,
                                    contactPerson.first_name + " " + contactPerson.last_name,
                                    null,
                                    contactPerson.salutation,
                                    contactPerson.first_name,
                                    contactPerson.last_name,
                                    contactPerson.email,
                                    contactPerson.phone,
                                    contactPerson.mobile,
                                    contactPerson.skype,
                                    null,
                                    contactPerson.department,
                                    contactPerson.designation,
                                    null,
                                    null,
                                    null,
                                    null,
                                    contactPerson.is_primary_contact ? "Yes" : "No"
                                };

                                string contactParamString = CommonLogic.ConvertToParamStringWithNull(contactParam);

                                await _iZohoInvoice.InsertUpdateZohoContactPerson(contactParamString);
                            }
                        }
                    }
                }
            }
        }       

        #region Private Methods

        //[HttpGet("FetchContactPersonFromCustomerID")]
        private async Task<string> FetchContactPersonFromCustomerID(long customerID, long zohoOrganizationId)
        {
            string refreshToken = await GetTokenFromDatabase("ZohoInvoiceAccessToken", "RefreshToken");
            string accessToken = await GetTokenFromDatabase("ZohoInvoiceAccessToken", "AccessToken");
          
            string url = $"{Convert.ToString(_iConfiguration["ZohoInvoiceBaseURL"])}/contacts/{customerID}/contactpersons";

            string response = "";

            if (!string.IsNullOrEmpty(accessToken))
            {
                response = CommonLogic.CoreHttpCallsGetForZohoInvoice(url, accessToken, Convert.ToString(zohoOrganizationId));
                if (response != null && response == "Unauthorized")
                {
                    // generate access token using refresh token.
                    accessToken = await RefreshAccessToken(refreshToken);

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        response = CommonLogic.CoreHttpCallsGetForZohoInvoice(url, accessToken, Convert.ToString(zohoOrganizationId));
                    }
                }
            }

            return response;
        }

        private async Task<string> RefreshAccessToken(string refreshToken)
        {
            try
            {
                string? tokenEndpoint = Convert.ToString(_iConfiguration["ZohoInvoiceAccessTokenURL"]);
                string? clientId = Convert.ToString(_iConfiguration["ZohoInvoiceClientID"]);
                string? clientSecret = Convert.ToString(_iConfiguration["ZohoInvoiceClientSecret"]);

                var requestData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("client_id", clientId), // Replace with your client ID
                    new KeyValuePair<string, string>("client_secret", clientSecret), // Replace with your client secret
                    new KeyValuePair<string, string>("refresh_token", refreshToken)
                });

                var response = await _httpClient.PostAsync(tokenEndpoint, requestData);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic? tokenData = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                    if (tokenData != null)
                    {
                        string? newAccessToken = tokenData.access_token;
                        await SaveTokensToDatabase("ZohoInvoiceAccessToken", newAccessToken, refreshToken);
                        return newAccessToken; // Return new access and refresh tokens
                    }
                }

                return null; // Return null if the refresh token failed
            }
            catch (Exception ex)
            {
                throw;
            }
        }

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

        #endregion
    }
}
