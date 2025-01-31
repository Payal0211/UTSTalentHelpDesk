using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class TS_Sproc_Get_Zoho_Tickets_BasedOnUser_Result
    {
        public long? TicketId { get; set; }
        public string? TicketNumber { get; set; }
        public string? ZohoTicketId { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Channel { get; set; }
        public string? WebUrl { get; set; }
        public string? CreatedTimeStr { get; set; }
        public string? ModifiedTimeStr { get; set; }
        public string? TalentName { get; set; }
        public string? TalentEmail { get; set; }
        public long? TalentId { get; set; }
        public string? ContactName { get; set; }
        public string? TicketClassification { get; set; }
        public string? AMName { get; set; }
        public long? TotalRecords { get; set; }
    }
}
