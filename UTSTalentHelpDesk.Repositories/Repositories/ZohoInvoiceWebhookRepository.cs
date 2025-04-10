using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Helpers;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Repositories.Interfaces;

namespace UTSTalentHelpDesk.Repositories.Repositories
{
    public class ZohoInvoiceWebhookRepository : IZohoInvoice
    {
        #region Variables
        private UTSTalentHelpDeskDBConnection _db;
        #endregion

        #region Constructor
        public ZohoInvoiceWebhookRepository(UTSTalentHelpDeskDBConnection db)
        {
            this._db = db;
        }
        #endregion

        #region public methods

        public async Task InsertUpdateZohoCustomers(string paramString)
        {
            string sql = $"EXEC {Constants.ProcConstant.SP_ZOHO_Customer_InsertORUpdate} {paramString}";
            await _db.Database.ExecuteSqlRawAsync(sql);
        }

        public async Task InsertUpdateZohoContactPerson(string paramString)
        {
            string sql = $"EXEC {Constants.ProcConstant.SP_ZOHO_ContactPerson_InsertORUpdate} {paramString}";
            await _db.Database.ExecuteSqlRawAsync(sql);
        }

        #endregion
    }
}
