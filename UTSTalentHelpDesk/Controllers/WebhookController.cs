using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Models.ViewModels;
using UTSTalentHelpDesk.Repositories.Interfaces;
using static UTSTalentHelpDesk.Models.ViewModels.ZohoWebhookPayload;

namespace UTSTalentHelpDesk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {

        private readonly ITicket _iTicket;
        private readonly IConfiguration _iConfiguration;
        private readonly IZohoInvoice _iZohoInvoice;
        public WebhookController(ITicket iTicket, IConfiguration iConfiguration, IZohoInvoice iZohoInvoice)
        {
            _iTicket = iTicket;
            _iConfiguration = iConfiguration;
            _iZohoInvoice = iZohoInvoice;
        }

        [HttpPost("zoho-webhook")]
        public async Task<IActionResult> HandleZohoWebhook()
        {

            List<ZohoWebhookPayload>? webhookPayload = new List<ZohoWebhookPayload>();
            PayloadDetails payload = new PayloadDetails();
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string xxjson = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(xxjson) || xxjson.Trim() == "{}")
                {
                    return Ok(new { status = "success" });
                    // return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "No request body." });
                }

                long Id = await SaveZohoWebHookLogs(xxjson);
                webhookPayload = JsonConvert.DeserializeObject<List<ZohoWebhookPayload>>(xxjson);
                payload = webhookPayload?[0].Payload;
                if (Id > 0)
                {
                    object[] paramwebhook = new object[] {
                                Id,
                                payload?.Id,
                                webhookPayload?[0].EventTime,
                                webhookPayload?[0].EventType,
                                webhookPayload?[0].OrgId,
                                null
                            };
                    string paramasStringwebhook = CommonLogic.ConvertToParamStringWithNull(paramwebhook);

                    _iTicket.saveZohoWebHookEvent(paramasStringwebhook);
                }

                if (payload != null)
                {
                    if (webhookPayload?[0].EventType == "Ticket_Add")
                    {
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
                        payload.IsResponseOverdue,
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
                        null,
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
                        decimal.TryParse(payload.Cf?.SeverityPercentage ?? "0", out decimal severity) ? severity : 0,
                        payload.Cf?.DateOfPurchase,
                        payload.Cf?.Url ?? string.Empty,
                        // Webhook Details
                        webhookPayload[0].EventTime,
                        webhookPayload[0].EventType,
                        webhookPayload[0].OrgId,
                        payload.WebUrl
                    };
                        string paramasString = CommonLogic.ConvertToParamString(param);

                        _iTicket.SaveZohoWebHookTickets(paramasString);
                    }
                    else if (webhookPayload?[0].EventType == "Ticket_Delete")
                    {
                        object[] param = new object[] {
                            // Ticket Main Details
                            payload.Id,                    
                            // Webhook Details
                            webhookPayload[0].EventTime,
                            webhookPayload[0].EventType,
                            webhookPayload[0].OrgId
                        };
                        string paramasString = CommonLogic.ConvertToParamString(param);

                        // Call update method
                        _iTicket.deleteZohoTickets(paramasString);
                    }
                }

            }
            // Process the incoming webhook data from Zoho
            // You can handle the incoming JSON here and trigger any logic you need
            return Ok(new { status = "success" });
        }

        [HttpPost("zoho-webhookUpdate")]
        public async Task<IActionResult> HandleZohoWebhookUpdate()
        {
            List<ZohoWebhookPayload>? webhookPayload = new List<ZohoWebhookPayload>();
            PayloadDetails payload = new PayloadDetails();
           
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string xxjson = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(xxjson) || xxjson.Trim() == "{}")
                {
                    return Ok(new { status = "success", message = "Webhook processed successfully" });
                }

                long Id = await SaveZohoWebHookLogs(xxjson);
                // Deserialize JSON payload to the ZohoWebhookPayload list
                try
                {
                    webhookPayload = JsonConvert.DeserializeObject<List<ZohoWebhookPayload>>(xxjson);

                    // Extract payload and prevState only if deserialization succeeds and the list has data
                    if (webhookPayload != null && webhookPayload.Count > 0)
                    {
                        payload = webhookPayload[0].Payload;                       

                        // Save webhook event details
                        if (Id > 0)
                        {
                            object[] paramwebhook = new object[] {
                                Id,
                                payload?.Id,
                                webhookPayload[0].EventTime,
                                webhookPayload[0].EventType,
                                webhookPayload[0].OrgId,
                                null
                            };
                            string paramasStringwebhook = CommonLogic.ConvertToParamString(paramwebhook);

                            _iTicket.saveZohoWebHookEvent(paramasStringwebhook);
                        }

                        // Save ticket updates
                        if (payload != null && webhookPayload[0].EventType == "Ticket_Update")
                        {
                            // Save Current Ticket State
                            object[] param = new object[] {
                            payload.Id,
                            payload.TicketNumber,
                            payload.Subject,
                            payload.Description,
                            payload.Status,
                            payload.StatusType,
                            payload.Priority ?? string.Empty,
                            payload.Category,
                            payload.SubCategory ?? string.Empty,
                            payload.Channel,
                            payload.ChannelCode ?? string.Empty,
                            payload.Source?.Type ?? string.Empty,
                            payload.Source?.AppName ?? string.Empty,
                            payload.ContactId,
                            payload.Contact?.FirstName ?? string.Empty,
                            payload.Contact?.LastName ?? string.Empty,
                            payload.Contact?.Email ?? string.Empty,
                            payload.Contact?.Phone ?? string.Empty,
                            payload.Contact?.Mobile ?? string.Empty,
                            payload.AssigneeId,
                            payload.Assignee?.FirstName ?? string.Empty,
                            payload.Assignee?.LastName ?? string.Empty,
                            payload.Assignee?.Email ?? string.Empty,
                            payload.IsOverDue,
                            payload.IsTrashed,
                            payload.IsResponseOverdue,
                            payload.IsSpam,
                            payload.IsArchived,
                            payload.IsDeleted,
                            payload.IsEscalated,
                            payload.CreatedTime,
                            payload.ModifiedTime,
                            payload.DueDate,
                            payload.ClosedTime,
                            payload.CustomerResponseTime,
                            payload.ResponseDueDate,
                            null,
                            int.Parse(payload.ThreadCount ?? "0"),
                            int.Parse(payload.CommentCount ?? "0"),
                            int.Parse(payload.TaskCount ?? "0"),
                            int.Parse(payload.ApprovalCount ?? "0"),
                            int.Parse(payload.AttachmentCount ?? "0"),
                            payload.DepartmentId ?? string.Empty,
                            payload.TeamId ?? string.Empty,
                            payload.ProductId ?? string.Empty,
                            payload.AccountId ?? string.Empty,
                            payload.LayoutDetails?.Id ?? string.Empty,
                            payload.LayoutDetails?.LayoutName ?? string.Empty,
                            decimal.TryParse(payload.Cf?.SeverityPercentage ?? "0", out decimal severity) ? severity : 0,
                            payload.Cf?.DateOfPurchase,
                            payload.Cf?.Url ?? string.Empty,
                            webhookPayload[0].EventTime,
                            webhookPayload[0].EventType,
                            webhookPayload[0].OrgId,
                            "",
                            payload.Classification
                        };
                            string paramasString = CommonLogic.ConvertToParamStringWithNull(param);

                            _iTicket.SaveZohoWebHookTickets(paramasString);                           
                        }
                    }
                }
                catch (JsonException ex)
                {
                    // Handle JSON deserialization errors
                    return BadRequest(new { status = "error", message = "Invalid JSON payload.", error = ex.Message });
                }


            }

            // Respond with a success message
            return Ok(new { status = "success", message = "Webhook processed successfully" });
        }

        [HttpPost("zoho-webhookDelete")]
        public async Task<IActionResult> HandleZohoWebhookDelete()
        {                   

            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string xxjson = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(xxjson) || xxjson.Trim() == "{}")
                {
                    return Ok(new { status = "success", message = "Webhook processed successfully" });
                }

                long Id = await SaveZohoWebHookLogs(xxjson);
                // Deserialize JSON payload to the ZohoWebhookPayload list
                try
                {
                    List<ZohoTicketDelete>? webhookPayload = new List<ZohoTicketDelete>();
                    DeletePayload payload = new DeletePayload();

                    webhookPayload = JsonConvert.DeserializeObject<List<ZohoTicketDelete>>(xxjson);

                    // Extract payload and prevState only if deserialization succeeds and the list has data
                    if (webhookPayload != null && webhookPayload.Count > 0)
                    {
                        payload = webhookPayload[0].payload;                       

                        // Save webhook event details
                        if (Id > 0)
                        {
                            object[] paramwebhook = new object[] {
                                Id,
                                payload?.id,
                                webhookPayload[0].eventTime,
                                webhookPayload[0].eventType,
                                webhookPayload[0].orgId,
                                null
                            };
                            string paramasStringwebhook = CommonLogic.ConvertToParamString(paramwebhook);

                            _iTicket.saveZohoWebHookEvent(paramasStringwebhook);
                        }

                        // delete ticket
                        if (payload != null && webhookPayload[0].eventType == "Ticket_Delete")
                        {
                            // Save Current Ticket State
                            object[] param = new object[] {
                                payload.id,
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
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                true,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                DateTime.Now, // Deleted time
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
                                null
                            };
                            string paramasString = CommonLogic.ConvertToParamStringWithNull(param);

                            _iTicket.SaveZohoWebHookTickets(paramasString);
                        }
                    }
                }
                catch (JsonException ex)
                {
                    // Handle JSON deserialization errors
                    return BadRequest(new { status = "error", message = "Invalid JSON payload.", error = ex.Message });
                }
            }

            // Respond with a success message
            return Ok(new { status = "success", message = "Webhook processed successfully" });
        }

        #region ZohoInvoiceWebhooks     

        [HttpPost("ZohoCustomerWebhook")]
        public async Task<IActionResult> ZohoCustomerWebhook()
        {
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string xxjson = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(xxjson) || xxjson.Trim() == "{}")
                {
                    return Ok(new { status = "success" });
                }

                long Id = await SaveZohoWebHookLogs(xxjson);

                DateTime localTime = DateTime.Now;
                long unixMs = new DateTimeOffset(localTime).ToUnixTimeMilliseconds();

                if (Id > 0)
                {
                    object[] paramwebhook = new object[]
                    {
                       Id,
                       0,
                       unixMs,
                       "Customer_Webhook",
                       Convert.ToString(_iConfiguration["ZohoInvoiceOrgID"]),
                       null
                    };
                    string paramasStringwebhook = CommonLogic.ConvertToParamStringWithNull(paramwebhook);

                    _iTicket.saveZohoWebHookEvent(paramasStringwebhook);
                }
                // Process the incoming webhook data from Zoho
                // You can handle the incoming JSON here and trigger any logic you need

                ZohoWebhookCustomer customerDetails = JsonConvert.DeserializeObject<ZohoWebhookCustomer>(xxjson);

                long zohoOrganizationID = Convert.ToInt64(_iConfiguration["ZohoInvoiceOrgID"]);

                if (customerDetails != null)
                {
                    WebhookContact contact = customerDetails.contact;
                    
                    // Save each customer in DB.
                    object[] param = new object[] {

                            zohoOrganizationID,
                            contact.contact_id,
                            contact.contact_name,
                            contact.contact_name,
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

                    if (contact.contact_persons != null)
                    {
                        foreach (var contactPerson in contact.contact_persons)
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

            return Ok(new { status = "success" });
        }

        [HttpPost("ZohoInvoiceWebhook")]
        public async Task<IActionResult> ZohoInvoiceWebhook()
        {
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string xxjson = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(xxjson) || xxjson.Trim() == "{}")
                {
                    return Ok(new { status = "success" });
                }

                long Id = await SaveZohoWebHookLogs(xxjson);

                DateTime localTime = DateTime.Now;
                long unixMs = new DateTimeOffset(localTime).ToUnixTimeMilliseconds();

                if (Id > 0)
                {
                    object[] paramwebhook = new object[]
                    {
                       Id,
                       0,
                       unixMs,
                       "Invoice_Webhook",
                       Convert.ToString(_iConfiguration["ZohoInvoiceOrgID"]),
                       null
                    };
                    string paramasStringwebhook = CommonLogic.ConvertToParamStringWithNull(paramwebhook);

                    _iTicket.saveZohoWebHookEvent(paramasStringwebhook);
                }

                // Process the incoming webhook data from Zoho
                // You can handle the incoming JSON here and trigger any logic you need

                ZohoInvoiceWebhook? invoiceData = JsonConvert.DeserializeObject<ZohoInvoiceWebhook>(xxjson);
                if (invoiceData != null)
                {
                    WebhookInvoice dto = invoiceData.invoice;

                    object[] param = new object[]
                    {
                       null,
                       dto.invoice_id,
                       null,
                       dto.customer_id,
                       dto.status,
                       dto.invoice_number,
                       null,
                       dto.due_date,
                       null,//dto.PaymentTermsId,
                       dto.currency_code,
                       dto.exchange_rate,
                       dto.tax_total,
                       dto.total,
                       dto.total,
                       null,//dto.CreatedBy,
                       null,//dto.ModifiedBy,
                       null,//dto.Balance,
                       dto.billing_address?.address,
                       null, // shipping address
                       dto.notes,
                       dto.terms,
                       dto.salesperson_id,
                       dto.salesperson_name,
                       null, //dto.CompanyId, // UTS_CompanyId
                       null, //dto.ContactId, // UTS_ContactId
                       null, //dto.CompanyName,
                       null, //dto.OrganizationId, // Zoho_OrganizationID
                       null, //dto.IsUpdated,
                       true,
                       null,
                       null,
                       null,
                       dto.custom_field_hash?.cf_number_of_invoice, //dto.CfNumberOfInvoice,
                       null,
                       dto.custom_field_hash?.cf_invoice_generator,
                       null,
                       null
                    };

                    string paramasString = CommonLogic.ConvertToParamStringWithNull(param);
                    _iZohoInvoice.InsertOrUpdateInvoiceAsync(paramasString);                    
                }
            }
            return Ok(new { status = "success" });
        }

        #endregion

        #region Save into ZohoWebHook Event Table
        private async Task<long> SaveZohoWebHookLogs(string json)
        {
            try
            {
                TsGenZohoTicketsWebhookEvent genZohoTicketsWebhookEvent = new TsGenZohoTicketsWebhookEvent();
                genZohoTicketsWebhookEvent.Payload = json;

                long ZohoWebHookInsertedID = await _iTicket.InsertZohoWebHookLogs(genZohoTicketsWebhookEvent);

                return ZohoWebHookInsertedID;
            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }
}
