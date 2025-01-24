using Microsoft.Extensions.Configuration;
using System.Dynamic;
using UTSTalentHelpDesk.Models.Models;
using Newtonsoft.Json;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ViewModels;

namespace UTSTalentHelpDesk
{
    public static class CustomRendering
    {
        private static string workingDirectory = Environment.CurrentDirectory;

        public static dynamic LoginResponse(GenTalent genTalent, IConfiguration _iConfiguration,string SSOUserName, string SSOUserEmailId,
                                             bool isRefresh = false, bool isFromAdmin = false, long ssoUserId = 0)
        {
            dynamic responseObject = new ExpandoObject();
            responseObject.LoggedInUserNameTC = genTalent.EmailId;
            responseObject.FullName = genTalent.Name;
            responseObject.LoggedInUserID = genTalent.Id;           
            responseObject.IsFromAdminLogin = isFromAdmin;
            responseObject.SSOLoggedInUserId = ssoUserId;           
            responseObject.SSOUserName = SSOUserName;
            responseObject.SSOUserEmailId = SSOUserEmailId;
            responseObject.ProfilePhoto = genTalent.ProfileUrl;

            // If the call is for refresh then do not generate the tokens again and make an entry in history
            if (!isRefresh)
            {                
                SessionValuesObject sessionValues = new SessionValuesObject()
                {
                    SSOUserID = ssoUserId,
                    LoggedInFromAdmin = isFromAdmin
                };

                responseObject.Token = CommonLogic.CreateToken(genTalent, _iConfiguration, sessionValues);                
            }

            return responseObject;
        }  
        
    }
}
