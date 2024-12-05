using Microsoft.Extensions.Configuration;
using System.Dynamic;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Repositories.Interfaces;
using Newtonsoft.Json;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ViewModels;

namespace UTSTalentHelpDesk
{
    public static class CustomRendering
    {
        private static string workingDirectory = Environment.CurrentDirectory;

        public static dynamic LoginResponse(GenTalent genTalent, IConfiguration _iConfiguration, IAccount _iAccount,
                                             bool isRefresh = false, bool isFromAdmin = false, long ssoUserId = 0)
        {
            dynamic responseObject = new ExpandoObject();
            responseObject.LoggedInUserNameTC = genTalent.EmailId;
            responseObject.FullName = genTalent.Name;
            responseObject.LoggedInUserID = genTalent.Id;
            responseObject.UserRoleID = 1;
            responseObject.IsFromAdminLogin = isFromAdmin;
            responseObject.SSOLoggedInUserId = ssoUserId;
            responseObject.SSOUserName = string.Empty;

            // UTS-7509: Fetch the SSO user name.
            if (ssoUserId > 0)
            {
                UsrUser user = _iAccount.UserDetails(ssoUserId).Result;
                if (user != null)
                {
                    responseObject.SSOUserName = user.FullName;
                    responseObject.SSOUserEmailId = user.EmailId;
                }
            }

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

        //public static dynamic AdminLoginResponse(UsrUser usrUser, IConfiguration _iConfiguration)
        //{
        //    dynamic responseObject = new ExpandoObject();
        //    responseObject.Token = CommonLogic.CreateToken(usrUser, _iConfiguration);
        //    //responseObject.Token = Helpers.CommonLogic.CreateToken(usrUser.EmployeeId, _iConfiguration["JWT:Key"], _iConfiguration["JWT:Issuer"]);
        //    responseObject.LoggedInUserNameTC = usrUser.Username;
        //    responseObject.LoggedInUserProfilePic = usrUser.ProfilePic;
        //    responseObject.LoggedInUserTypeID = usrUser.UserTypeId;
        //    responseObject.FullName = usrUser.FullName;
        //    responseObject.EmployeeID = usrUser.EmployeeId ?? "";
        //    responseObject.Designation = usrUser.Designation ?? "";
        //    return responseObject;
        //}
        public static string ForgotPasswordTemplate(string link)
        {
            string path = string.Format(@"{0}\{1}\{2}\{3}.html", workingDirectory,"Templates","ForgotPassword","forgotpwd");
            string html = File.ReadAllText(path);
            html = html.Replace("##resetLink##", link);
            return html;

        }

        public static dynamic EmptyRows()
        {
            dynamic responseObject = new ExpandoObject();
            responseObject.Data = new List<string>();
            responseObject.TotalRows = 0;
            return responseObject;
        }

        public static dynamic AllResponse<T>(List<T> modelList, long TotalRecords)
        {
            dynamic responseObject = new ExpandoObject();
            responseObject.Data = modelList;
            responseObject.TotalRows = modelList.Count;
            responseObject.TotalRecords = TotalRecords;
            return responseObject;
        }

        public static dynamic ListingResponses<T>(List<T> modelList, long TotalRecords,long requestRecordCount,long pagenumber)
        {
            dynamic responseObject = new ExpandoObject();
            responseObject.totalPages = requestRecordCount > 0 ?  (int)Math.Ceiling((float)TotalRecords / (float)requestRecordCount) : requestRecordCount;
            responseObject.pagenumber = pagenumber;
            responseObject.totalrows = TotalRecords;
            responseObject.rows = modelList;
            return responseObject;
        }
        public static dynamic FilterListsResponse(object FilterLists)
        {
            dynamic responseObject = new ExpandoObject();
            responseObject.Data = FilterLists;
            
            return responseObject;
        }

        public static dynamic HRListingResponses<T>(List<T> modelList, long TotalRecords, long requestRecordCount, long pagenumber)
        {
            dynamic responseObject = new ExpandoObject();
            responseObject.totalPages = requestRecordCount > 0 ? (int)Math.Ceiling((float)TotalRecords / (float)requestRecordCount) : requestRecordCount;
            responseObject.pagenumber = pagenumber;
            responseObject.totalrows = TotalRecords;
            responseObject.rows = modelList;
            return responseObject;
        }

        
    }
}
