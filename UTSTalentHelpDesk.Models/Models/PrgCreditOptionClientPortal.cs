using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgCreditOptionClientPortal
    {
        public long Id { get; set; }
        public string? OptionDesc { get; set; }
        public decimal? CreditUsed { get; set; }
        public int? CreditAmountId { get; set; }
    }
}
