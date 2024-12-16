using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenCompanyConfidentialAlias
    {
        public long Id { get; set; }
        public long? CompanyId { get; set; }
        public string? Company { get; set; }
        public string? CompanyUrl { get; set; }
        public string? CompanyLinkedIn { get; set; }
        public string? CompanyHq { get; set; }
        public long? LastModifiedbyId { get; set; }
        public DateTime? LastModifiedbyDate { get; set; }
        public string? CompanyLogo { get; set; }
    }
}
