using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.Models
{
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
