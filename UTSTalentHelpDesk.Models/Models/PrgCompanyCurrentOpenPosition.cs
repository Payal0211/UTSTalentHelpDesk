﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgCompanyCurrentOpenPosition
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal? Weighted { get; set; }
        public decimal? WeightedPercentage { get; set; }
    }
}
