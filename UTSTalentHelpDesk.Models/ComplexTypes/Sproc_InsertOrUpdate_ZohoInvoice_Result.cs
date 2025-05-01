using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class Sproc_InsertOrUpdate_ZohoInvoice_Result
    {
        public long InsertedInvoiceID { get; set; }
        public string? Contact_Person_ID { get; set; }
        public string? InvNumber { get; set; }
        public int? InvCount { get; set; }
    }
}
