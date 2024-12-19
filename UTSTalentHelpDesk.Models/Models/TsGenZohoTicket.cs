using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class TsGenZohoTicket
    {
        public long TicketId { get; set; }
        public string? ZohoTicketId { get; set; }
        public string TicketNumber { get; set; } = null!;
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? StatusType { get; set; }
        public string? Priority { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ClosedTime { get; set; }
        public DateTime? CustomerResponseTime { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ContactId { get; set; }
        public string? AssigneeId { get; set; }
        public string? DepartmentId { get; set; }
        public long? TalentId { get; set; }
        public int? UtsUserId { get; set; }
        public string? Channel { get; set; }
        public string? WebUrl { get; set; }
        public bool? IsOverDue { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsTrashed { get; set; }
        public bool? IsEscalated { get; set; }
        public bool? IsSpam { get; set; }
        public bool? IsArchieved { get; set; }
    }
}
