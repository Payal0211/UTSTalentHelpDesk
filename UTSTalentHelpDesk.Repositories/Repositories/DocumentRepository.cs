using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Helpers;
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
    }
}
