using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    [Keyless]
    public class TicketRequest
    {
        public string Subject { get; set; }
        public string DepartmentId { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
