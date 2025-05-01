using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.ComplexTypes;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface IZohoInvoice
    {
        Task InsertUpdateZohoCustomers(string paramString);
        Task InsertUpdateZohoContactPerson(string paramString);
        Sproc_InsertOrUpdate_ZohoInvoice_Result InsertOrUpdateInvoiceAsync(string parameterString);
        Task<long> InsertOrUpdateLineItemAsync(string paramString);
    }
}
