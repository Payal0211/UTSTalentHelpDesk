using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenJobScrappingException
    {
        public long Id { get; set; }
        public long? CompanyId { get; set; }
        public string? FileName { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorObject { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
