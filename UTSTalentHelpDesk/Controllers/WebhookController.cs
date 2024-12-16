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
        public WebhookController(ITicket iTicket)
        {
            _iTicket = iTicket;
        }

        [HttpPost("zoho-webhook")]
        public async Task<IActionResult> HandleZohoWebhook()
        {

            List<ZohoWebhookPayload>? webhookPayload = new List<ZohoWebhookPayload>();
            PayloadDetails payload = new PayloadDetails();
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string xxjson = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(xxjson))
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
                    string paramasStringwebhook = CommonLogic.ConvertToParamString(paramwebhook);

                    _iTicket.saveZohoWebHookEvent(paramasStringwebhook);
                }

                if (payload != null)
                {
                    if(webhookPayload?[0].EventType == "Ticket_Add")
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
                        webhookPayload[0].OrgId
                    };
                        string paramasString = CommonLogic.ConvertToParamString(param);

                        _iTicket.SaveZohoWebHookTickets(paramasString);
                    }
                    else if(webhookPayload?[0].EventType == "Ticket_Delete")
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
            PrevStateDetails prevState = new PrevStateDetails();

            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string xxjson = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(xxjson))
                {
                    return Ok(new { status = "success" });
                }

                long Id = await SaveZohoWebHookLogs(xxjson);
                webhookPayload = JsonConvert.DeserializeObject<List<ZohoWebhookPayload>>(xxjson);

                if (webhookPayload != null && webhookPayload.Count > 0)
                {
                    payload = webhookPayload[0].Payload;
                    prevState = webhookPayload[0].PrevState;

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
                            webhookPayload[0].OrgId
                        };
                        string paramasString = CommonLogic.ConvertToParamString(param);

                        _iTicket.SaveZohoWebHookTickets(paramasString);

                        // Save Previous Ticket State
                        if (prevState != null)
                        {
                            object[] prevParam = new object[] {
                                prevState.Id,
                                prevState.TicketNumber,
                                prevState.Subject,
                                prevState.Description,
                                prevState.Status,
                                prevState.StatusType,
                                prevState.Priority ?? string.Empty,
                                prevState.Category,
                                prevState.SubCategory ?? string.Empty,
                                prevState.Channel,
                                prevState.ChannelCode ?? string.Empty,
                                prevState.Source?.Type ?? string.Empty,
                                prevState.Source?.AppName ?? string.Empty,
                                prevState.ContactId,
                                prevState.Contact?.FirstName ?? string.Empty,
                                prevState.Contact?.LastName ?? string.Empty,
                                prevState.Contact?.Email ?? string.Empty,
                                prevState.Contact?.Phone ?? string.Empty,
                                prevState.Contact?.Mobile ?? string.Empty,
                                prevState.AssigneeId,
                                prevState.Assignee?.FirstName ?? string.Empty,
                                prevState.Assignee?.LastName ?? string.Empty,
                                prevState.Assignee?.Email ?? string.Empty,
                                prevState.IsOverDue,
                                prevState.IsTrashed,
                                prevState.IsResponseOverdue,
                                prevState.IsSpam,
                                prevState.IsArchived,
                                prevState.IsDeleted,
                                prevState.IsEscalated,
                                prevState.CreatedTime,
                                prevState.ModifiedTime,
                                prevState.DueDate,
                                prevState.ClosedTime,
                                prevState.CustomerResponseTime,
                                prevState.ResponseDueDate,
                                null,
                                int.Parse(prevState.ThreadCount ?? "0"),
                                int.Parse(prevState.CommentCount ?? "0"),
                                int.Parse(prevState.TaskCount ?? "0"),
                                int.Parse(prevState.ApprovalCount ?? "0"),
                                int.Parse(prevState.AttachmentCount ?? "0"),
                                prevState.DepartmentId ?? string.Empty,
                                prevState.TeamId ?? string.Empty,
                                prevState.ProductId ?? string.Empty,
                                prevState.AccountId ?? string.Empty,
                                prevState.LayoutDetails?.Id ?? string.Empty,
                                prevState.LayoutDetails?.LayoutName ?? string.Empty,
                                decimal.TryParse(prevState.CustomFields?.SeverityPercentage ?? "0", out decimal prevSeverity) ? prevSeverity : 0,
                                prevState.CustomFields?.DateOfPurchase,
                                prevState.CustomFields?.Url ?? string.Empty,
                                webhookPayload[0].EventTime,
                                webhookPayload[0].EventType,
                                webhookPayload[0].OrgId
                            };
                            string prevParamasString = CommonLogic.ConvertToParamString(prevParam);

                            _iTicket.SaveZohoWebHookPrevTickets(prevParamasString);
                        }
                    }
                }
            }

            return Ok(new { status = "success" });
        }


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
