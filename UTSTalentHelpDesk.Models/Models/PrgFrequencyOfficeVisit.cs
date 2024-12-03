using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgFrequencyOfficeVisit
    {
        public int Id { get; set; }
        public string? Frequency { get; set; }
        public bool? IsActive { get; set; }
    }
}
