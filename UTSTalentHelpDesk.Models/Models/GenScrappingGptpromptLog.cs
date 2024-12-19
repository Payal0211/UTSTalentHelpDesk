using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenScrappingGptpromptLog
    {
        public long Id { get; set; }
        public string? PromptText { get; set; }
        public string? JobId { get; set; }
        public string? Gptresponse { get; set; }
        public DateTime? CreatedByDateTime { get; set; }
    }
}
