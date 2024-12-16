using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenJobPostTransactionHistoryClientPortal
    {
        public long Id { get; set; }
        public long? Hrid { get; set; }
        public long? ContactId { get; set; }
        public long? ContactUserId { get; set; }
        public DateTime? JobPostedDate { get; set; }
        public DateTime? JobRepostedDate { get; set; }
        public int? CreditBalance { get; set; }
        public bool? IsReposted { get; set; }
        public string? BalanceUsedType { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? CreatedByDateTime { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public long? CompanyId { get; set; }
        public long? SubScriptionId { get; set; }
        public long? TalentId { get; set; }
        public int? CreditOptionId { get; set; }
        public long? AtsTalentId { get; set; }
        public decimal? JpcreditBalance { get; set; }
        public decimal? UtilizedCreditAmount { get; set; }
        public string? UtilizedCreditCurreny { get; set; }
        public decimal? CreditUsed { get; set; }
        public string? CreditTransactionNumber { get; set; }
        public int? AppActionDoneBy { get; set; }
    }
}
