using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenCompanyApplyUrldetail
    {
        public long Id { get; set; }
        public long? CompanyId { get; set; }
        public string? ApplyUrlFields { get; set; }
        public string? JobId { get; set; }
    }
}
