﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgHistoryChannelAction
    {
        public long Id { get; set; }
        public string ActionName { get; set; } = null!;
        public string? DisplayName { get; set; }
        public bool IsActive { get; set; }
    }
}
