﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgClientInvoiceStatus
    {
        public int Id { get; set; }
        public string? InvoiceStatus { get; set; }
        public bool? IsActive { get; set; }
    }
}
