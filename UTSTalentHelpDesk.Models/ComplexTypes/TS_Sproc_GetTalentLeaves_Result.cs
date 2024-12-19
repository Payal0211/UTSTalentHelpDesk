using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class TS_Sproc_GetTalentLeaves_Result
    {
        public string? LeaveID { get; set; } // Primary Key
        public long? TalentID { get; set; } // Talent for which leave is applied
        public string? LeaveDate { get; set; } // Leave start date
        public string? LeaveDuration { get; set; } // ENUM('Full Day', 'Half Day')
        public string? LeaveReason { get; set; } // Reason for the leave
        public string? LeaveRejectionRemark { get; set; } // Reason for the leave rejection
        public string? Status { get; set; } // ENUM('Pending', 'Approved', 'Rejected')
        public DateTime? CreatedDate { get; set; } // Leave request added on which date
        public long? ApprovedBy { get; set; } // Who approved the leave
        public DateTime? ApprovalDate { get; set; } // Date of approval
        public bool? IsApprovedByAM { get; set; } // Flag to maintain if AM user approved the leave on behalf of the client
        public long? RejectedBy { get; set; } // Rejected leave by whom
        public DateTime? RejectedDate { get; set; } // Leave rejected date
        public bool? IsRejectedByAM { get; set; } // Leave rejected by AM
        public bool? IsActive { get; set; } // If leave is deleted then IsActive = 0
        public string? TalentName { get; set; }
        public string? ApprovedByName { get; set; }
        public string? RejectedByName { get; set; }
    }
}
