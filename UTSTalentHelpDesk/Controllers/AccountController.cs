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
                long talentId = 0;

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
                        talentId = Convert.ToInt64(MyExtensions.Decrypt(Uri.UnescapeDataString(talentLogin.EncryptedTalentId)));
                        var userId = MyExtensions.Decrypt(Uri.UnescapeDataString(talentLogin.EncryptedUserId));                       
                        ssoUserId = Convert.ToInt64(userId);
                    }
                    else
                    {                       
                        ssoUserId = 0;
                    }

                    genTalent = _iAccounts.LoginUser(talentLogin.username, talentLogin.password, isFromAdminLogin, talentId);

                    if (genTalent != null)
                    {
                        UsrUser user = await _iAccounts.UserDetails(ssoUserId);
                        if (user != null)
                        {
                            SSOUserName = user.FullName;
                            SSOUserEmailId = user.EmailId;
                        }

                        var result = CustomRendering.LoginResponse(genTalent, _iConfiguration, SSOUserName, SSOUserEmailId, isFromAdmin: isFromAdminLogin, ssoUserId: ssoUserId);

                        bool resultIsAddTokenInMemory = await _iAccounts.IsAddTokenInMemory(result.Token, result.LoggedInUserNameTC);                      

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

        #region LoginWithOTP

        [HttpPost("LoginWithOTP")]
        [AllowAnonymous]
        public async Task<ObjectResult> LoginWithOTP([FromBody] TalentLoginUserWithOtp talentLogin)
        {
            try
            {
                #region Validation
                if (talentLogin == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Request object is empty" });
                }
                #endregion
               
                long talentId = 0;

                List<Tuple<string, string, string>> employee = new List<Tuple<string, string, string>>();

                employee.Add(new Tuple<string, string, string>("notempty", talentLogin.username, "Username"));

                List<string> errors = new Validator(employee).Validate();

                if (errors.Count == 0)
                {
                    GenTalent? genTalent = null;                   

                    genTalent = await _iAccounts.TalentDetails(talentLogin.username, talentId);

                    if (genTalent != null)
                    {
                        talentId = genTalent.Id;
                        string otp = GenerateOTP();
                        _iAccounts.LoginWithOTP(talentId, otp, false);

                        EmailBinder emailBinder = new EmailBinder(_iConfiguration, _iEmail);
                        emailBinder.SendOTP(genTalent, otp);

                        return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Authentication is Done", Details = genTalent });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Username is invalid, please try again.", Details = errors });
                    }
                }
                else
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Validation Failed", Details = errors });
            }
            catch(Exception e) 
            {
                throw e;
            }
        }

        [HttpPost("ValidateOTP")]
        [AllowAnonymous]
        public async Task<ObjectResult> ValidateOTP([FromBody] TalentLoginUserWithOtp talentLogin)
        {
            try
            {
                #region Validation
                if (talentLogin == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Request object is empty" });
                }
                #endregion

                long talentId = 0;

                List<Tuple<string, string, string>> employee = new List<Tuple<string, string, string>>();

                employee.Add(new Tuple<string, string, string>("notempty", talentLogin.username, "Username"));
                employee.Add(new Tuple<string, string, string>("notempty", talentLogin.OTP, "OTP"));

                List<string> errors = new Validator(employee).Validate();

                if (errors.Count == 0)
                {
                    GenTalent? genTalent = null;

                    genTalent = await _iAccounts.TalentDetails(talentLogin.username, talentId);

                    if (genTalent != null)
                    {
                        talentId = genTalent.Id;
                        string otp = talentLogin.OTP;
                        GenTalentDetail talentDetail = _iAccounts.LoginWithOTP(talentId, otp, true);
                        if (talentDetail != null)
                        {
                            return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "Authentication is Done", Details = genTalent });
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Invalid OTP.", Details = talentLogin });
                        }
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Username is invalid, please try again.", Details = errors });
                    }
                }
                else
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Validation Failed", Details = errors });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("ResendOTP")]
        [AllowAnonymous]
        public async Task<ObjectResult> ResendOTP([FromBody] TalentLoginUserWithOtp talentLogin)
        {
            try
            {
                #region Validation
                if (talentLogin == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Request object is empty" });
                }
                #endregion

                long talentId = 0;

                List<Tuple<string, string, string>> employee = new List<Tuple<string, string, string>>();

                employee.Add(new Tuple<string, string, string>("notempty", talentLogin.username, "Username"));

                List<string> errors = new Validator(employee).Validate();

                if (errors.Count == 0)
                {
                    GenTalent? genTalent = null;

                    genTalent = await _iAccounts.TalentDetails(talentLogin.username, talentId);

                    if (genTalent != null)
                    {
                        talentId = genTalent.Id;
                        string otp = GenerateOTP();
                        _iAccounts.LoginWithOTP(talentId, otp, false);

                        EmailBinder emailBinder = new EmailBinder(_iConfiguration, _iEmail);
                        emailBinder.SendOTP(genTalent, otp);

                        return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "OTP send successfully", Details = genTalent });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Username is invalid, please try again.", Details = errors });
                    }
                }
                else
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseObject() { statusCode = StatusCodes.Status400BadRequest, Message = "Validation Failed", Details = errors });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [NonAction]
        private string GenerateOTP()
        {
            try
            {
                string OTP = "";                 

                Random random = new Random();              

                OTP = Convert.ToString(random.Next(10000, 99999));

                return OTP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

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
            }
            return StatusCode(StatusCodes.Status200OK, new ResponseObject() { statusCode = StatusCodes.Status200OK, Message = "success", Details = result });
        }
        #endregion
    }
}
