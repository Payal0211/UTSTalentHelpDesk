using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Helpers;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Repositories.Interfaces;
using UTSTalentHelpDesk.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using RestSharp;
using System.Dynamic;

namespace UTSTalentHelpDesk.Controllers
{
    [Route("Account/", Name = "Login Signup")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Variables
        private readonly IAccount _iAccounts;
        private readonly IConfiguration _iConfiguration;
        private readonly IEmail _iEmail;
        #endregion

        #region Constructors
        public AccountController(IAccount iAccounts, IConfiguration iConfiguration, IEmail iEmail)
        {
            _iAccounts = iAccounts;
            _iConfiguration = iConfiguration;
            _iEmail = iEmail;
        }
        #endregion

        #region Login
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ObjectResult> Login([FromBody] TalentLoginUser talentLogin)
        {
            try
            {
                #region Validation
                if (talentLogin == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Request object is empty" });
                }
                #endregion

                var isFromAdminLogin = Convert.ToBoolean(talentLogin.IsLoggedInFromAdmin);
                long ssoUserId = 0;
                var SSOUserName = "";
                var SSOUserEmailId = "";

                List<Tuple<string, string, string>> employee = new List<Tuple<string, string, string>>();
                if (isFromAdminLogin)
                {
                    employee.Add(new Tuple<string, string, string>("notempty", talentLogin.EncryptedTalentId, "EncryptedTalentId"));
                    employee.Add(new Tuple<string, string, string>("notempty", talentLogin.EncryptedUserId, "EncryptedUserId"));
                }
                else
                {
                    employee.Add(new Tuple<string, string, string>("notempty", talentLogin.username, "Username"));
                    employee.Add(new Tuple<string, string, string>("notempty", talentLogin.password, "Password"));
                }
                List<string> errors = new Validator(employee).Validate();

                if (errors.Count == 0)
                {
                    GenTalent? genTalent = null;

                    if (isFromAdminLogin)
                    {
                        var talentId = MyExtensions.Decrypt(Uri.UnescapeDataString(talentLogin.EncryptedTalentId));
                        var userId = MyExtensions.Decrypt(Uri.UnescapeDataString(talentLogin.EncryptedUserId));
                        genTalent = await _iAccounts.LoginUserFromAdmin(talentId).ConfigureAwait(false);
                        ssoUserId = Convert.ToInt64(userId);
                    }
                    else
                    {
                        genTalent = await _iAccounts.LoginUser(talentLogin.username, talentLogin.password).ConfigureAwait(false);
                        ssoUserId = 0;
                    }


                    if (genTalent != null)
                    {
                        UsrUser user = _iAccounts.UserDetails(ssoUserId).Result;
                        if (user != null)
                        {
                            SSOUserName = user.FullName;
                            SSOUserEmailId = user.EmailId;
                        }


                        var result = CustomRendering.LoginResponse(genTalent, _iConfiguration, SSOUserName, SSOUserEmailId, isFromAdmin: isFromAdminLogin, ssoUserId: ssoUserId);

                        bool resultIsAddTokenInMemory = await _iAccounts.IsAddTokenInMemory(result.Token, result.LoggedInUserNameTC);

                        //UTS-6698: SSO login - for credit based client  it shown OTP verification page 
                        object[] param = new object[] { genTalent.Id };
                        string paramString = CommonLogic.ConvertToParamString(param);

                        string strQueryData = CommonLogic.Encrypt($"{DateTime.Now.AddDays(1).Ticks}#{genTalent.Id}");
                        result.TalentDashboardUrl = $"{_iConfiguration.GetValue("TalentHelpDeskPortalURL", "")}TalentHelpDesk/TalentHelpDeskLoginFromReact?data={strQueryData}";

                        result.IsEmailVerified = true;

                        return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Authentication is Done", Details = result });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Username or password is invalid, please try again.", Details = errors });
                    }
                }
                else
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Validation Failed", Details = errors });
            }
            catch
            {
                throw;
            }
        }
        #endregion

        [Authorize]
        [HttpGet("RedirectToDashboard")]
        public async Task<ObjectResult> RedirectToDashboard()
        {
            long TalentId = SessionValues.LoginUserId;

            string strQueryData = CommonLogic.Encrypt($"{DateTime.Now.AddMinutes(5).Ticks}#{TalentId}");

            return StatusCode(StatusCodes.Status200OK, new ResponseObject()
            {
                statusCode = StatusCodes.Status200OK,
                Message = "Open this URL in new tab.",
                Details = new
                {
                    redirectURL = $"{_iConfiguration.GetValue("TalentHelpDeskPortalURL", "")}TalentHelpDesk/TalentHelpDeskLoginFromReact?data={strQueryData}"
                }
            });
        }


        #region Logout
        [Authorize]
        [HttpGet("LogOut")]
        public async Task<ObjectResult> LogOut(string token)
        {
            bool logoutResult = await _iAccounts.IsLogoutUser(token);

            if (logoutResult)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Logout" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Logout" });
            }
        }
        #endregion


        #region ReloadLocalStorageWhileRefresh

        [Authorize]
        [HttpPost("ReloadLocalStorageWhileRefresh")]
        public async Task<ObjectResult> ReloadLocalStorageWhileRefresh([FromBody] LogoutToken tokens)
        {
            #region PreValidation
            if (tokens == null)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Request object is empty, please check the datatype or naming convention" });
            }
            #endregion

            long talentId = Convert.ToInt64(SessionValues.LoginUserId);
            GenTalent genTalent = await _iAccounts.TalentDetails("", talentId);
            dynamic result = new ExpandoObject();
            
            long ssoUserId = Convert.ToInt64(SessionValues.SSOLoggedInUserId);
            bool isFromAdmin = false;
            if (ssoUserId > 0)
            {
                isFromAdmin = true;
            }
           

            if (genTalent != null)
            {
                string EmailID = genTalent.EmailId;
                string Name = genTalent.Name;
                result = CustomRendering.LoginResponse(genTalent, _iConfiguration, Name, EmailID, isRefresh: true, isFromAdmin: isFromAdmin, ssoUserId: ssoUserId);
                result.Token = tokens.Token;

                object[] param = new object[] { genTalent.Id };
                string paramString = CommonLogic.ConvertToParamString(param);

                string strQueryData = CommonLogic.Encrypt($"{DateTime.Now.AddDays(1).Ticks}#{genTalent.Id}");
                result.TalentDashboardUrl = $"{_iConfiguration.GetValue("TalentHelpDeskPortalURL", "")}TalentHelpDesk/TalentHelpDeskLoginFromReact?data={strQueryData}";

            }
            return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "success", Details = result });
        }
        #endregion
    }
}
