﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgPartialEngagementType
    {
        public int Id { get; set; }
        public string? PartialEngagementType { get; set; }
        public bool? IsActive { get; set; }
    }
}
