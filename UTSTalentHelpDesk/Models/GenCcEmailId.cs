﻿using System;
using System.Collections.Generic;

namespace TalentConnectAdminAPI.Models
{
    public partial class GenCcEmailId
    {
        public int Id { get; set; }
        public string CcemailIds { get; set; } = null!;
        public string CcemailNames { get; set; } = null!;
    }
}
