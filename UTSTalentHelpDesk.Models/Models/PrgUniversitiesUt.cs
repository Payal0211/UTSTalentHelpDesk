using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgUniversitiesUt
    {
        public long Id { get; set; }
        public string University { get; set; } = null!;
        public string? ShortName { get; set; }
        public string? RevisedUniversity { get; set; }
        public bool? IsActive { get; set; }
    }
}
