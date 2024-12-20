using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.ComplexTypes;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface ILeaveRequest
    {
        Task InsertUpdateLeaves(string param);
        Task ApproveRejectRevokeTalentLeaves(string param);
        Task<List<TS_Sproc_GetTalentLeaves_Result>> Get_Talent_LeavesList(string param);
        Task<List<TS_Sproc_Get_Talent_Leaves_Monthly_Calendar_Result>> Get_Talent_LeavesList_Monthly(string param);
    }
}
