﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgCreditOptionsWithHrtypeId
    {
        public int Id { get; set; }
        public int? CreditOptionId { get; set; }
        public int? HrtypeId { get; set; }
    }
}
