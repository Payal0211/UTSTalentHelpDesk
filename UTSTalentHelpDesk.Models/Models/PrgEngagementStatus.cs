using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgEngagementStatus
    {
        public int Id { get; set; }
        public string? EngagementStatus { get; set; }
        public bool? IsActive { get; set; }
    }
}
