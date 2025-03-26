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
    public class LeaveRequestRepository : ILeaveRequest
    {
        #region Variables
        private UTSTalentHelpDeskDBConnection _db;
        #endregion

        #region Constructor
        public LeaveRequestRepository(UTSTalentHelpDeskDBConnection db)
        {
            _db = db;
        }
        #endregion

        #region public methods

        public async Task InsertUpdateLeaves(string param)
        {
            await _db.Database.ExecuteSqlRawAsync(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_Insert_Update_Talent_Leaves, param));
        }

        public async Task ApproveRejectRevokeTalentLeaves(string param)
        {
            await _db.Database.ExecuteSqlRawAsync(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_Approve_Reject_Revoke_Talent_Leaves, param));
        }
        public async Task<List<TS_Sproc_GetTalentLeaves_Result>> Get_Talent_LeavesList(string param)
        {
            return await _db.Set<TS_Sproc_GetTalentLeaves_Result>().FromSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_GetTalentLeaves, param)).ToListAsync();
        }
        public async Task<List<TS_Sproc_Get_Talent_Leaves_Monthly_Calendar_Result>> Get_Talent_LeavesList_Monthly(string param)
        {
            return await _db.Set<TS_Sproc_Get_Talent_Leaves_Monthly_Calendar_Result>().FromSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_Get_Talent_Leaves_Monthly_Calendar, param)).ToListAsync();
        }

        public async Task<List<TsPrgLeaveType>> GetLeaveTypes()
        {
            return await _db.TsPrgLeaveTypes.ToListAsync();
        }

        public async Task<List<TS_Sproc_GetLeaveBalance_History_Result>> GetLeaveBalance_History_Results(string param)
        {
            return await _db.Set<TS_Sproc_GetLeaveBalance_History_Result>().FromSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_GetLeaveBalance_History, param)).ToListAsync();
        }

        #endregion
    }
}
