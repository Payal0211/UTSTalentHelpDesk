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
        Task<GenTalent> LoginUser(string username, string password);
        Task<bool> IsTalentExists(string emailId);
        Task<bool> IsAddTokenInMemory(string token, string userId);
        Task<IList<JwtTokenDataModel>> GetActiveTokenList();
        Task<bool> IsLogoutUser(string token); 
        Task<GenTalent> TalentDetailByEmail(string emailId);       
        Task<bool> TalentDetailIsPasswordChanged(long Id);
        Task<GenTalent> GetGenTalentByUserName(string userName);
        Task<UsrUser> UserDetails(long id = 0);
        Task<GenTalent> LoginUserFromAdmin(string username);
        Task<GenTalent> TalentDetails(string emailId, long id = 0);

    }
}
