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
        public decimal? PR { get; set; }       
        public string? ContractType { get; set; }
        public DateTime? ClientInvoiceDate { get; set; }
        public string? EngagementId_HRID { get; set; }
        public int? AM_SalesPersonID { get; set; }
        public string? AM_UserName { get; set; }
        public int? TSC_PersonID { get; set; }
        public string? TSC_UserName { get; set; }
    }
}
