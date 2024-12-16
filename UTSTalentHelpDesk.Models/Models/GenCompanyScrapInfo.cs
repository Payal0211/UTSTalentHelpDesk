using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenCompanyScrapInfo
    {
        public long Id { get; set; }
        public string? Company { get; set; }
        public string? Website { get; set; }
        public string? Url { get; set; }
        public string? Location { get; set; }
        public bool? IsActive { get; set; }
        public string? Payload { get; set; }
        public long? Atsid { get; set; }
    }
}
