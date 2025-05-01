using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.Models
{
    public class ZohoCustomerWebhook
    {
        public string Auth_Key { get; set; }
        public string Auth_Token { get; set; }
        public string Customer_Id { get; set; }
        //public ZohoContactJSonString JSONString { get; set; }
    }
    public partial class ZohoCustomer
    {
        public long? Zoho_Organization_ID { get; set; }
        public string Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Display_Name { get; set; }
        public string EmailID { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
