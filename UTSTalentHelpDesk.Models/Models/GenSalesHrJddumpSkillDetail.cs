﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenSalesHrJddumpSkillDetail
    {
        public long Id { get; set; }
        public long? JddumpId { get; set; }
        public long? SkillId { get; set; }
        public string? TempSkillId { get; set; }
    }
}
