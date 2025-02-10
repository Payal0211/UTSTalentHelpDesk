using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenTalentDetail
    {
        public long Id { get; set; }
        public long? TalentId { get; set; }
        public string? TalentUplersId { get; set; }
        public string? Otp { get; set; }
        public DateTime? OtpCreatedDate { get; set; }
        public DateTime? OtpExpiredDate { get; set; }
        public bool? OtpIsActive { get; set; }
        public int? OtpvalidationCount { get; set; }
    }
}
