using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class TalentLoginUser
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public bool? IsFromAdmin { get; set; }
        public bool? IsLoggedInFromAdmin { get; set; } = false;
        public string? EncryptedTalentId { get; set; }
        public string? EncryptedUserId { get; set; }
    }
}
