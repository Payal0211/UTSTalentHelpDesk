using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class TS_Sproc_Get_engagement_PRDetails_MonthWise_Result
    {
        public long? ID { get; set; }
        public long? OnBoardID { get; set; }
        public int? Months { get; set; }
        public int? Years { get; set; }
        public string? EngagemenID { get; set; }
        public string? Currency { get; set; }
        public string? MonthNames { get; set; }
        public decimal? BR { get; set; }
        public string? BRStr { get; set; }
        public int? TotalDaysinMonth { get; set; }
        public decimal? PR_Per_Day { get; set; }
        public string? PR_Per_DayStr { get; set; }
        public string? PR_Per_DayWithExchangeRate { get; set; }
        public int? LeavesTaken { get; set; }
        public decimal? Amount_To_Be_Deducted { get; set; }
        public string? Amount_To_Be_DeductedStr { get; set; }
        public decimal? PR { get; set; }
        public string? PRStr { get; set; }
        public decimal? Final_PR { get; set; }
        public string? Final_PRStr { get; set; }
        public decimal? NR_DP_Value { get; set; }
        public string? NR_DP_ValueStr { get; set; }
        public decimal? Actual_NR_Percentage { get; set; }
        public string? ContractType { get; set; }
        public DateTime? ClientInvoiceDate { get; set; }
        public string? EngagementId_HRID { get; set; }
        public int? AM_SalesPersonID { get; set; }
        public string? AM_UserName { get; set; }
        public int? TSC_PersonID { get; set; }
        public string? TSC_UserName { get; set; }
        public decimal? ExchangeRate { get; set; }
    }
}
