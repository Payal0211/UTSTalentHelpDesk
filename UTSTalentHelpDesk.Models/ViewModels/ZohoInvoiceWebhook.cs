using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class ZohoInvoiceWebhook
    {
        public string InvoiceID { get; set; }
        public string Auth_Key { get; set; }
        public string Auth_Token { get; set; }
        public string InvoiceStatus { get; set; }        
    }
}
