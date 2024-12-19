using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class TsGenTalentDocument
    {
        public long Id { get; set; }
        public int? DocumentTypeId { get; set; }
        public long? TalentId { get; set; }
        public string? DocumentName { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDateTime { get; set; }
    }
}
