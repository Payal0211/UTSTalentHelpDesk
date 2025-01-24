using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.Models;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface IAccount
    {
        GenTalent LoginUser(string username, string password, bool isFromAdmin, long talentId);       
        Task<bool> IsAddTokenInMemory(string token, string userId);
        Task<IList<JwtTokenDataModel>> GetActiveTokenList();
        Task<bool> IsLogoutUser(string token);        
        Task<UsrUser> UserDetails(long id = 0);       
        Task<GenTalent> TalentDetails(string emailId, long id = 0);
    }
}
