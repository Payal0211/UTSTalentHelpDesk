using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class TsGenZohoContact
    {
        public long Id { get; set; }
        public string? ZohoContactId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? OwnerId { get; set; }
        public string? AccountId { get; set; }
        public string? WebUrl { get; set; }
    }
}
