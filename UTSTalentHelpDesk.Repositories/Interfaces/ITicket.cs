using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.ComplexTypes;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface ITicket
    {
        void CreateTicket(string param);
        void UpdateTicket(string param);
        Task<sp_GetToken_Result> GetTokenList(string strparams);
    }
}
