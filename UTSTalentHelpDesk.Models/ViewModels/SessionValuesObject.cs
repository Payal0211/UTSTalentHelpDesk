using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class SessionValuesObject
    {
        public long? SSOUserID { get; set; }
        public bool? LoggedInFromAdmin { get; set; }
    }
}
