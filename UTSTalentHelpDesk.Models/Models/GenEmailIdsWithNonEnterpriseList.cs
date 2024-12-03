using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenEmailIdsWithNonEnterpriseList
    {
        public long Id { get; set; }
        public string? EmailId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? ClientName { get; set; }
        public string? CompanyName { get; set; }
        public long? CompanyId { get; set; }
    }
}
