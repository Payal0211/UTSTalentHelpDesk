﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgTalentPayoutStatus
    {
        public int Id { get; set; }
        public string? PayOutStatus { get; set; }
        public bool? IsActive { get; set; }
    }
}
