using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class TsGenTalentTicket
    {
        public long Id { get; set; }
        public long? TalentId { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ZohoTicketId { get; set; }
    }
}
