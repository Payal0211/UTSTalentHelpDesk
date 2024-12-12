using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class TS_Sproc_Get_DashBoradCounts_Result
    {
        public int? NoOfAppliedJobs { get; set; }
        public int? OpenTickets { get; set; }
        public int? ClosedTickets { get; set; }
        public decimal? NoOfLeavesTaken { get; set; }
        public long? TalentID { get; set; }
        public string? TalentName { get; set; }
    }
}
