using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgInstitutesCollege
    {
        public long Id { get; set; }
        public string IntituteCollegeName { get; set; } = null!;
        public string? ShortName { get; set; }
        public string? RevisedIntituteCollegeName { get; set; }
        public long? UniversityId { get; set; }
        public bool? IsActive { get; set; }
    }
}
