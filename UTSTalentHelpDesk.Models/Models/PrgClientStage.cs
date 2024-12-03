﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgClientStage
    {
        public int Id { get; set; }
        public string ClientStageName { get; set; } = null!;
        public int? Sequence { get; set; }
        public string? ActionId { get; set; }
    }
}
