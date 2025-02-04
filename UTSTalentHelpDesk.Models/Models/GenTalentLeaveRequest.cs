using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenTalentLeaveRequest
    {
        public long Id { get; set; }
        public long? TalentId { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string? LeaveDuration { get; set; }
        public string? LeaveReason { get; set; }
        public string? LeaveRejectionRemark { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public bool? IsApprovedByAm { get; set; }
        public long? RejectedBy { get; set; }
        public DateTime? RejectedDate { get; set; }
        public bool? IsRejectedByAm { get; set; }
        public bool? IsActive { get; set; }
        public string? LeaveId { get; set; }
        public string? ActionFileName { get; set; }
        public int? AppActionDoneBy { get; set; }
        public long? CompanyId { get; set; }
    }
}
