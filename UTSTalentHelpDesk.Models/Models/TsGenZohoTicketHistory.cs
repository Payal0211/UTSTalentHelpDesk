using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class TsGenZohoTicketHistory
    {
        public long Id { get; set; }
        public long? TicketId { get; set; }
        public string? ActionDetails { get; set; }
        public int? ActionSource { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedByDatetime { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedByDatetime { get; set; }
    }
}
