﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenTalentPreferableWorkingDetail
    {
        public long Id { get; set; }
        public long? TalentId { get; set; }
        public int? PreferableWorkingId { get; set; }
        public bool? IsAddedAfterPostAcceptance { get; set; }
    }
}
