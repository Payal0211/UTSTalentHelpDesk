using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenOnBoardedTalentNote
    {
        public long Id { get; set; }
        public long? HiringRequestId { get; set; }
        public long? OnBoardId { get; set; }
        public long? TalentId { get; set; }
        public string? Notes { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? CreatedByDateTime { get; set; }
        public int? AppActionDoneBy { get; set; }
    }
}
