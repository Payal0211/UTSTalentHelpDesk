﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgOrgLevel
    {
        public long Id { get; set; }
        public string LevelName { get; set; } = null!;
        public int? LevelOrder { get; set; }
    }
}
