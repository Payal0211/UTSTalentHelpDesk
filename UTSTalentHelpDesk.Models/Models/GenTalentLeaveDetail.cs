using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenTalentLeaveDetail
    {
        public long Id { get; set; }
        public long? OnBoardId { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public int? PaidLeaves { get; set; }
        public int? HolidayLeaves { get; set; }
        public int? TotalLeaves { get; set; }
        public DateTime? CreatedbyDateTime { get; set; }
    }
}
