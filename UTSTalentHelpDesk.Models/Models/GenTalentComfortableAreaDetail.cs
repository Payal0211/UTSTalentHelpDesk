﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenTalentComfortableAreaDetail
    {
        public long Id { get; set; }
        public long? TalentId { get; set; }
        public int? ComfortableAreaId { get; set; }
    }
}
