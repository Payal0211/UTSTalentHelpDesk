using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Repositories.Interfaces;

namespace UTSTalentHelpDesk.Repositories.Repositories
{
    public class ZohoInvoiceWebhookRepository : IZohoInvoice
    {
        #region Variables
        private UTSTalentHelpDeskDBConnection db;
        #endregion
        #region Constructor
        public ZohoInvoiceWebhookRepository(UTSTalentHelpDeskDBConnection _db)
        {
            this.db = _db;
        }
        #endregion
    }
}
