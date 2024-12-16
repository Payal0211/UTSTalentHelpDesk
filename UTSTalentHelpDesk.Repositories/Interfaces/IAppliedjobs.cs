using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.ComplexTypes;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface IAppliedjobs
    {
        Task<List<TS_Sproc_GetActive_EngagementList_Result>> GetActive_EngagementList(string strparams);
        Task<List<TS_Sproc_GetClose_EngagementList_Result>> GetClose_EngagementList(string strparams);
        Task<List<TS_Sproc_Get_engagement_PRDetails_MonthWise_Result>> GetEngagementPRDetailsMonthWiseResult(string strparams);
    }
}
