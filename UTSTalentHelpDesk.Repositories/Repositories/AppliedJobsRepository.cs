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
    public class AppliedJobsRepository : IAppliedjobs
    {
        #region Variables
        private UTSTalentHelpDeskDBConnection db;
        #endregion
        #region Constructor
        public AppliedJobsRepository(UTSTalentHelpDeskDBConnection _db)
        {
            this.db = _db;
        }
        #endregion
        public async Task<List<TS_Sproc_GetActive_EngagementList_Result>> GetActive_EngagementList(string strparams)
        {
            return await db.Set<TS_Sproc_GetActive_EngagementList_Result>().FromSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_GetActive_EngagementList, strparams)).ToListAsync();
        }
        public async Task<List<TS_Sproc_GetClose_EngagementList_Result>> GetClose_EngagementList(string strparams)
        {
            return await db.Set<TS_Sproc_GetClose_EngagementList_Result>().FromSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_GetClose_EngagementList, strparams)).ToListAsync();
        }
    }
}
