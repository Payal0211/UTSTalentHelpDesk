namespace UTSTalentHelpDesk.Helpers
{
    public static class Constants
    {
        /// <summary>
        /// ProcConstant
        /// </summary>
        public static class ProcConstant
        {
            #region Login
            public static string TS_Sproc_Talent_Login = "TS_Sproc_Talent_Login";
            public static string TS_Sproc_Talent_OTP_Verify = "TS_Sproc_Talent_OTP_Verify";
            #endregion

            #region Document
            public static string TS_Sproc_Add_Talent_Document = "TS_Sproc_Add_Talent_Document";
            public static string TS_Sproc_Get_Talent_DocumentList = "TS_Sproc_Get_Talent_DocumentList";
            public static string TS_Sproc_Verify_Talent_Document = "TS_Sproc_Verify_Talent_Document";
            public static string TS_Sproc_Remove_Talent_Document = "TS_Sproc_Remove_Talent_Document";
            #endregion

            #region Ticket
            public static string TS_sproc_GetToken = "TS_sproc_GetToken";
            public static string TS_sproc_SaveTokens = "TS_sproc_SaveTokens";
            public static string TS_sproc_UpdateToken = "TS_sproc_UpdateToken";
            public static string TS_Sproc_SaveAllTicketData = "TS_Sproc_SaveAllTicketData";
            public static string TS_sproc_SaveTicket = "TS_sproc_SaveTicket";
            public static string TS_Sproc_SaveZohoTicket = "TS_Sproc_SaveZohoTicket";
            public static string TS_Sproc_deleteZohoTicket = "TS_Sproc_deleteZohoTicket";
            public static string TS_Sproc_SaveZohoContacts = "TS_Sproc_SaveZohoContacts";
            public static string TS_Sproc_WebHook_History_Manage = "TS_Sproc_WebHook_History_Manage";
            public static string TS_Sproc_SaveZohoTicket_Webhook = "TS_Sproc_SaveZohoTicket_Webhook";
            public static string TS_Sproc_SaveZohoPrevTicket_Webhook = "TS_Sproc_SaveZohoPrevTicket_Webhook";
            public static string TS_Sproc_Get_Zoho_Tickets_BasedOnUser = "TS_Sproc_Get_Zoho_Tickets_BasedOnUser";
            #endregion

            #region Engagements
            public static string TS_Sproc_GetActive_EngagementList = "TS_Sproc_GetActive_EngagementList";
            public static string TS_Sproc_GetClose_EngagementList = "TS_Sproc_GetClose_EngagementList";
            public static string TS_Sproc_Get_engagement_PRDetails_MonthWise = "TS_Sproc_Get_engagement_PRDetails_MonthWise";
            #endregion

            #region Dashboard
            public static string TS_Sproc_Get_DashBoradCounts = "TS_Sproc_Get_DashBoradCounts";
            #endregion

            #region Leaves

            public const string TS_Sproc_Insert_Update_Talent_Leaves = "TS_Sproc_Insert_Update_Talent_Leaves";
            public const string TS_Sproc_Approve_Reject_Revoke_Talent_Leaves = "TS_Sproc_Approve_Reject_Revoke_Talent_Leaves";
            public const string TS_Sproc_GetTalentLeaves = "TS_Sproc_GetTalentLeaves";
            public const string TS_Sproc_Get_Talent_Leaves_Monthly_Calendar = "TS_Sproc_Get_Talent_Leaves_Monthly_Calendar";
            public const string TS_Sproc_Get_Talent_Contact_Details = "TS_Sproc_Get_Talent_Contact_Details";
            public const string TS_Sproc_GetLeaveBalance_History = "TS_Sproc_GetLeaveBalance_History";

            #endregion

            public static string sp_UTS_get_PasswordData = "sp_UTS_get_PasswordData";
            
        }
    }
}
