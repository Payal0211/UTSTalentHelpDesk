﻿using System;
using System.Collections.Generic;

namespace TalentConnectAdminAPI.Models
{
    public partial class GenSalesHiringRequestPriority
    {
        public long Id { get; set; }
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
    }
}
