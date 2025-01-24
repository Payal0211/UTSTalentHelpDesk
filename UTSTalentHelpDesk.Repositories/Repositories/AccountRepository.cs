using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Helpers;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
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

        public GenTalent LoginUser(string username, string password, bool isFromAdmin, long talentId)
        {
            try
            {
                object[] param = new object[]
                {
                    username,password,isFromAdmin,talentId
                };

                string paramasString = CommonLogic.ConvertToParamStringWithNull(param);               
                return _db.Set<GenTalent>().FromSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_Talent_Login, paramasString)).AsEnumerable().FirstOrDefault();
               
            }
            catch (Exception)
            {
                throw;
            }
        }                
        
        public async Task<UsrUser> UserDetails(long id = 0)
        {
            var user = await _unitOfWork.usrUsers.GetSingleByCondition(x => x.Id == id);
            return user;
        }

        public async Task<GenTalent> TalentDetails(string emailId, long id = 0)
        {
            GenTalent genTalent;
            if (string.IsNullOrEmpty(emailId))
            {
                genTalent = await _unitOfWork.genTalents.GetSingleByCondition(x => x.Id == id);

            }
            else
            {
                genTalent = await _unitOfWork.genTalents.GetSingleByCondition(x => x.EmailId.ToLower().Equals(emailId.ToLower()));
            }
            return genTalent;
        }
    }
}
