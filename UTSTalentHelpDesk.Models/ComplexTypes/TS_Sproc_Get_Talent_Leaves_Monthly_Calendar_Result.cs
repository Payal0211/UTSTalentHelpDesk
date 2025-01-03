using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class TS_Sproc_Get_Talent_Leaves_Monthly_Calendar_Result
    {
        public string? ActualDate { get; set; }
        public bool? IsLeave { get; set; }
        public string? LeaveType { get; set; }
        public string? DayOfWeeks { get; set; }
        public string? ColorCode { get; set; }
        public string? LeaveStatus { get; set; }
        public string? LeaveReason { get; set; }
    }
}
