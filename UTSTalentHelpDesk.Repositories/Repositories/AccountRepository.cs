using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Helpers;
using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Repositories.Interfaces;

namespace UTSTalentHelpDesk.Repositories.Repositories
{
    public class AccountRepository : IAccount
    {
        #region Variables
        private UTSTalentHelpDeskDBConnection _db;
        private IUnitOfWork _unitOfWork;
        private readonly InMemoryDbContext _dbcontext;

        #endregion

        #region Constructors
        public AccountRepository(UTSTalentHelpDeskDBConnection db, IUnitOfWork unitOfWork, InMemoryDbContext dbcontext)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _dbcontext = dbcontext;
        }

        #endregion
        public async Task<IList<JwtTokenDataModel>> GetActiveTokenList()
        {
            try
            {
                return await _dbcontext.JwtTokenDataModels.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GenTalent> GetGenTalentByUserName(string userName)
        {
            var result = await _unitOfWork.genTalents.GetAllByCondition(x => x.Username == userName && x.IsPasswordChanged == true && x.IsResetPassword == true);
            return result.OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public async Task<bool> IsAddTokenInMemory(string token, string userId)
        {
            try
            {
                if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(userId))
                {
                    JwtTokenDataModel objJwtTokenDataModel = new();
                    objJwtTokenDataModel.JwtToken = token;
                    objJwtTokenDataModel.UserId = userId;
                    _dbcontext.JwtTokenDataModels.Add(objJwtTokenDataModel);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
                else
                { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsLogoutUser(string token)
        {
            try
            {
                var result = _dbcontext.JwtTokenDataModels.Where(x => x.JwtToken == token).FirstOrDefault();

                if (result != null)
                {
                    _dbcontext.JwtTokenDataModels.Remove(result);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> IsTalentExists(string emailId)
        {
            var genTalent = await _unitOfWork.genTalents.GetSingleByCondition(x => x.EmailId.ToLower().Equals(emailId.ToLower()));
            return genTalent != null;
        }

        public async Task<GenTalent> LoginUser(string username, string password)
        {
            try
            {

                GenTalent genTalent;
                genTalent = await _unitOfWork.genTalents.GetSingleByCondition(x => x.EmailId.ToLower().Equals(username.ToLower()));
                if (genTalent != null)
                {
                    // Done by Riya to check the password with case sensitivity.
                    string? clientPassword = genTalent.Password;
                    if (clientPassword != null && clientPassword.Equals(password))
                    {
                        return genTalent;
                    }
                    else
                    {
                        if (genTalent != null)
                        {
                            genTalent.IsPasswordChanged = false;
                            _unitOfWork.genTalents.Update(genTalent);
                            _unitOfWork.Save();
                        }
                        genTalent = null;
                    }
                }
                return genTalent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenTalent> LoginUserFromAdmin(string TalentId)
        {
            try
            {
                GenTalent genTalent;
                long userTalentId = Convert.ToInt64(TalentId);
                genTalent = await _unitOfWork.genTalents.GetSingleByCondition(x => x.Id == userTalentId);
                return genTalent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenTalent> TalentDetailByEmail(string emailId)
        {
            return await _unitOfWork.genTalents.GetSingleByCondition(x => x.EmailId == emailId);
        }

        public async Task<bool> TalentDetailIsPasswordChanged(long Id)
        {
            GenTalent obj = await _unitOfWork.genTalents.GetSingleByCondition(x => x.Id == Id);
            if (obj != null)
            {
                obj.IsPasswordChanged = false;
                _unitOfWork.genTalents.Update(obj);
                _unitOfWork.Save();
            }
            return true;
        }

        public async Task<UsrUser> UserDetails(long id = 0)
        {
            var user = await _unitOfWork.usrUsers.GetSingleByCondition(x => x.Id == id);
            return user;
        }
    }
}
