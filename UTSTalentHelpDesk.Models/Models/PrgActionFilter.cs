using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgActionFilter
    {
        public int Id { get; set; }
        public string ActionFilter { get; set; } = null!;
        public string Color { get; set; } = null!;
    }
}
