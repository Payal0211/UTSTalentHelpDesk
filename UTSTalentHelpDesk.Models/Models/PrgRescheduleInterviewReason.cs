﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgRescheduleInterviewReason
    {
        public int Id { get; set; }
        public string? Reason { get; set; }
        public bool? IsActive { get; set; }
    }
}
