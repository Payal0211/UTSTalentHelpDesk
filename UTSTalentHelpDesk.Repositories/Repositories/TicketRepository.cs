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
    public class TicketRepository : ITicket
    {
        #region Variables
        private UTSTalentHelpDeskDBConnection db;
        #endregion
        #region Constructor
        public TicketRepository(UTSTalentHelpDeskDBConnection _db)
        {
            this.db = _db;
        }
        #endregion
        public void CreateTicket(string param)
        {
            db.Database.ExecuteSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_sproc_SaveTokens, param));
        }

        public async Task<TS_sproc_GetToken_Result> GetTokenList(string strparams)
        {
            return db.Set<TS_sproc_GetToken_Result>().FromSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_sproc_GetToken, strparams)).AsEnumerable().FirstOrDefault();
        }

        public void SaveAllTickets(string param)
        {
            db.Database.ExecuteSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_SaveAllTicketData, param));
        }
        public void SaveTickets(string param)
        {
            db.Database.ExecuteSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_sproc_SaveTicket, param));
        }
        public void UpdateTicket(string param)
        {
            db.Database.ExecuteSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_sproc_UpdateToken, param));
        }

        public void SaveZohoTickets(string param)
        {
            db.Database.ExecuteSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_SaveZohoTicket, param));
        }
        public void deleteZohoTickets(string param)
        {
            db.Database.ExecuteSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_deleteZohoTicket, param));
        }
    }
}
