﻿using System;
using System.Collections.Generic;

namespace TalentConnectAdminAPI.Models
{
    public partial class PrgCompanyTypeofInterviewer
    {
        public int Id { get; set; }
        public string? TypeofInterviewer { get; set; }
        public bool? IsActive { get; set; }
    }
}
