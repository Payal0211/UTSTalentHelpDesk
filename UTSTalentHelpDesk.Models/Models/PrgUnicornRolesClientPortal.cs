using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgUnicornRolesClientPortal
    {
        public long Id { get; set; }
        public string? RoleName { get; set; }
        public bool? IsActive { get; set; }
        public string? RoleImage { get; set; }
    }
}
