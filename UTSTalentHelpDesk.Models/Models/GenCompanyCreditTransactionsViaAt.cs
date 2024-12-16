using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenCompanyCreditTransactionsViaAt
    {
        public long Id { get; set; }
        public long? CompanyId { get; set; }
        public long? ContactId { get; set; }
        public long? HrId { get; set; }
        public long? AtstalentId { get; set; }
        public string? TransactionType { get; set; }
        public decimal? FreecreditUsed { get; set; }
        public decimal? PaidcreditUsed { get; set; }
        public decimal? CreditAmount { get; set; }
        public string? CreditCurrency { get; set; }
        public string? ActionType { get; set; }
        public decimal? BalanceCredit { get; set; }
        public string? EmployeeId { get; set; }
        public string? Transactiondoneby { get; set; }
        public string? TransactionDate { get; set; }
        public string? OrderId { get; set; }
        public decimal? OrderAmount { get; set; }
        public string? PaymentProvider { get; set; }
        public int? PaymentStatus { get; set; }
        public string? PayerName { get; set; }
        public string? PayerEmail { get; set; }
        public string? PayerId { get; set; }
        public string? OrderComments { get; set; }
        public string? InvoiceUrl { get; set; }
        public string? InvoiceName { get; set; }
    }
}
