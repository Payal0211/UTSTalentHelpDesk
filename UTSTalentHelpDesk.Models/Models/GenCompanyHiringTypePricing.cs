using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenCompanyHiringTypePricing
    {
        public long Id { get; set; }
        public long? CompanyId { get; set; }
        public int? HiringTypePricingId { get; set; }
        public decimal? HiringTypePercentage { get; set; }
        public bool? IsDefault { get; set; }
    }
}
