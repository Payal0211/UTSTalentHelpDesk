using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenScrapCompanyAt
    {
        public long Id { get; set; }
        public string? CompanyAts { get; set; }
        public bool? IsActive { get; set; }
    }
}
