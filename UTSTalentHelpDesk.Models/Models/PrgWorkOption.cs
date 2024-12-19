using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgWorkOption
    {
        public int Id { get; set; }
        public string? WorkOption { get; set; }
        public bool? Isactive { get; set; }
    }
}
