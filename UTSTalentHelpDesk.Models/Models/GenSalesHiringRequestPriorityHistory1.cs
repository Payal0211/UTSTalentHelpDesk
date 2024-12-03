﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenSalesHiringRequestPriorityHistory1
    {
        public long Id { get; set; }
        public long? Hid { get; set; }
        public long SalesUserId { get; set; }
        public long HiringRequestId { get; set; }
        public bool? IsPriority { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedByDatetime { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDatetime { get; set; }
        public DateTime? PriorityStartDate { get; set; }
        public DateTime? PriorityEndDate { get; set; }
        public bool? IsNextWeekPriority { get; set; }
        public DateTime? Dumpdatetime { get; set; }
    }
}
