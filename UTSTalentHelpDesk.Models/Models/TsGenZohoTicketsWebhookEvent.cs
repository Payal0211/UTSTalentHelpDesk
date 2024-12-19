using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class TsGenZohoTicketsWebhookEvent
    {
        public long Id { get; set; }
        public string? TicketUniqueId { get; set; }
        public string? EventTime { get; set; }
        public string? EventType { get; set; }
        public string? OrgId { get; set; }
        public string? Payload { get; set; }
    }
}
