﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenContactGetHelpQuestion
    {
        public long Id { get; set; }
        public long? ContactId { get; set; }
        public string? GetHelpQuestion { get; set; }
        public DateTime? CreatedByDatetime { get; set; }
    }
}
