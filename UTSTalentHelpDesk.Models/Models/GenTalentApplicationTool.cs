﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenTalentApplicationTool
    {
        public long Id { get; set; }
        public long? TalentId { get; set; }
        public int? ApplicationToolId { get; set; }
        public string? TempApplicationToolsId { get; set; }
    }
}
