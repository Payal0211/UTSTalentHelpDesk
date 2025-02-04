using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class LeaveRequestViewModel
    {
        public long? ID { get; set; } // primary key
        public long? TalentID { get; set; } // Talent for which leave is applied
        public DateTime? LeaveDate { get; set; } // Leave start date
        public DateTime? LeaveEndDate { get; set; } // Leave start date
        public string? LeaveDuration { get; set; } // ENUM('Full Day', 'Half Day')
        public string? LeaveReason { get; set; } // Reason for the leave       
        public string? Status { get; set; } // ENUM('Pending', 'Approved', 'Rejected')        
        public int? NoOfDays { get; set; }    
        public string? LeaveID { get; set; }    
        public long? CompanyID { get; set; }    
        public bool IsFromSalesPortal { get; set; } = true;
    }

    public class LeaveRequestActions
    {
        public string? LeaveID { get; set; } // primary key
        public long? ActionDoneBy { get; set; } // Who approved the leave    
        public bool? IsActionDoneByAM { get; set; } // Flag to maintain if AM user approved the leave on behalf of the client
        public string? LeaveRejectionRemark { get; set; } // Reason for the leave rejection
        public string? Flag { get; set; } // Approve, Reject, Revoke
        public List<IFormFile>? Files { get; set; }
    }

}
