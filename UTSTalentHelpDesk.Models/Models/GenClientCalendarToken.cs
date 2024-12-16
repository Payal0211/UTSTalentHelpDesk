using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenClientCalendarToken
    {
        public long Id { get; set; }
        public long? CompanyId { get; set; }
        public long? ContactId { get; set; }
        public string? EmailId { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? CalendarType { get; set; }
        public DateTime? CreatedByDateTime { get; set; }
    }
}
