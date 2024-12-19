using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenZohoToken
    {
        public int Id { get; set; }
        public string? TokenName { get; set; }
        public string? RefreshToken { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
