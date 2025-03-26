using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class TsPrgLeaveType
    {
        public long Id { get; set; }
        public string? LeaveType { get; set; }
        public bool? IsActive { get; set; }
    }
}
