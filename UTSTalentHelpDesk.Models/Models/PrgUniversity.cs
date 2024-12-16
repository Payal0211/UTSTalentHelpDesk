using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgUniversity
    {
        public long Id { get; set; }
        public string? University { get; set; }
        public string? ShortName { get; set; }
        public string? RevisedUniversity { get; set; }
        public bool? IsActive { get; set; }
    }
}
