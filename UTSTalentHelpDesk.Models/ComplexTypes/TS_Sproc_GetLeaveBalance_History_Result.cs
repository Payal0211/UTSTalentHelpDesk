using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class TS_Sproc_GetLeaveBalance_History_Result
    {
        public string? LeaveID { get; set; }
        public long? TalentID { get; set; }
        public long? OnBoardID { get; set; }
        public string? LeaveType { get; set; }
        public string? LeaveAction { get; set; }
        public string? LeaveDuration { get; set; }
        public string? LeaveReason { get; set; }
        public string? LeaveDates { get; set; }
        public decimal? LeavesTaken { get; set; }
        public decimal? LeaveBalance { get; set; }
        public long? HistoryID { get; set; }
    }
}
