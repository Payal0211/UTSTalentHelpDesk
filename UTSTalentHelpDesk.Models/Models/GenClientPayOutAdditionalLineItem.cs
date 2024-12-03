﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenClientPayOutAdditionalLineItem
    {
        public long Id { get; set; }
        public long? PayOutId { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }
        public int? Action { get; set; }
    }
}
