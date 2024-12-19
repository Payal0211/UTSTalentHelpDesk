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
    public class DocumentRepository : IDocument
    {
        #region Variables
        private UTSTalentHelpDeskDBConnection db;
        #endregion

        #region Constructor
        public DocumentRepository(UTSTalentHelpDeskDBConnection _db)
        {
            this.db = _db;
        }
        #endregion
        public void CreateDocument(string param)
        {
            db.Database.ExecuteSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_Add_Talent_Document, param));
        }
        public async Task<List<TS_Sproc_Get_Talent_DocumentList_Result>> Get_Talent_DocumentList(string param)
        {
            return await db.Set<TS_Sproc_Get_Talent_DocumentList_Result>().FromSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_Get_Talent_DocumentList, param)).ToListAsync();
        }

        public void VerifyDocument(string param)
        {
            db.Database.ExecuteSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_Verify_Talent_Document, param));
        }

        public void RemoveDocument(string param)
        {
            db.Database.ExecuteSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_Remove_Talent_Document, param));
        }
    }
}
