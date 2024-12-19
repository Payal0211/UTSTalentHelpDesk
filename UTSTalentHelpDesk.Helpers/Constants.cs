namespace UTSTalentHelpDesk.Helpers
{
    public static class Constants
    {
        /// <summary>
        /// ProcConstant
        /// </summary>
        public static class ProcConstant
        {
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
            #endregion

            #region Engagements
            public static string TS_Sproc_GetActive_EngagementList = "TS_Sproc_GetActive_EngagementList";
            public static string TS_Sproc_GetClose_EngagementList = "TS_Sproc_GetClose_EngagementList";
            public static string TS_Sproc_Get_engagement_PRDetails_MonthWise = "TS_Sproc_Get_engagement_PRDetails_MonthWise";
            #endregion

            #region Dashboard
            public static string TS_Sproc_Get_DashBoradCounts = "TS_Sproc_Get_DashBoradCounts";
            #endregion
        }
    }
}
