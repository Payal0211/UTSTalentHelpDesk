using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgTalentJoinning
    {
        public int Id { get; set; }
        public string? Joinning { get; set; }
        public bool? IsActive { get; set; }
    }
}
