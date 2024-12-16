using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenCompanyScrapHistory
    {
        public long Id { get; set; }
        public long? CompanyId { get; set; }
        public DateTime? ScrapedDate { get; set; }
        public int? NoOfJobsScraped { get; set; }
    }
}
