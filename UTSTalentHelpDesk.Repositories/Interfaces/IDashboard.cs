using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.ComplexTypes;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface IDashboard
    {
        void DashBoardCount();

        Task<List<TS_Sproc_Get_DashBoradCounts_Result>> GetDashBoradCounts(string strparams);
    }
}
