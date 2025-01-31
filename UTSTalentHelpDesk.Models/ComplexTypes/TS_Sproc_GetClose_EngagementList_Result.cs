using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class TS_Sproc_GetClose_EngagementList_Result
    {
        public string? JobTitle { get; set; }
        public string? Company { get; set; }
        public string? Client { get; set; }
        public string? AM { get; set; }
        public string? Joiningdate { get; set; }
        public string? ContractStartDate { get; set; }
        public string? ContractEndDate { get; set; }
        public string? LastWorkingDate { get; set; }
        public decimal? ActualPayRate { get; set; }
        public string? PayRateCurrency { get; set; }
        public string? ActualPayRateStr { get; set; }
        public long? OnBoardId { get; set; }
        public long? HRID { get; set; }
        public string? WorkingDays { get; set; }
        public string? ShiftStartTime { get; set; }
        public string? ShiftEndTime { get; set; }
    }
}
