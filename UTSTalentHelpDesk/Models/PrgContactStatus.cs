﻿using System;
using System.Collections.Generic;

namespace TalentConnectAdminAPI.Models
{
    public partial class PrgContactStatus
    {
        public int Id { get; set; }
        public string? ContactStatus { get; set; }
        public bool? IsActive { get; set; }
        public string? Color { get; set; }
    }
}
