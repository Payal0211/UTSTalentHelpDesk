using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgState
    {
        public int Id { get; set; }
        public string? State { get; set; }
        public int? CountryId { get; set; }
    }
}
