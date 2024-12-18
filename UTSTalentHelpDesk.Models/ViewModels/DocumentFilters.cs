using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class DocumentFilters
    {
        public IEnumerable<SelectListItem> DocumentType { get; set; }
    }
}
