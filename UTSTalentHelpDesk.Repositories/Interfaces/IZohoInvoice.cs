using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface IZohoInvoice
    {
        Task InsertUpdateZohoCustomers(string paramString);
        Task InsertUpdateZohoContactPerson(string paramString);
    }
}
