using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class TsPrgDocumentType
    {
        public int Id { get; set; }
        public string? DocumentType { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsOfficial { get; set; }
    }
}
