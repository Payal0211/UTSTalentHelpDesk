﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgHiringRequestRoleStatus
    {
        public int Id { get; set; }
        public string? HiringRequestRoleStatus { get; set; }
        public int? HrStatusId { get; set; }
        public bool? IsActive { get; set; }
        public string? Color { get; set; }
    }
}
