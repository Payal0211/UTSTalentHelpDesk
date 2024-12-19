using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class ImageUpload
    {
        public List<IFormFile> Files { get; set; }       
        public int? DocumentTypeID { get; set; }
        public long? TalentID { get; set; }
        public string? DocumentName { get; set; }        
    }
}
