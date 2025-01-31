using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class TS_Sproc_Get_Talent_DocumentList_Result
    {
        public long? TalentDocumentID { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentType { get; set; }
        public string? UploadDate { get; set; }
        public string? Status { get; set; }
        public string? ApprovedBy { get; set; }
        public string? ApprovedDateTime { get; set; }
        public string? Unique_FileName { get; set; }
    }
}
