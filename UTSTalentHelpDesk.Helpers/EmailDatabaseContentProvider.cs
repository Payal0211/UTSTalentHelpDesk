﻿namespace UTSTalentHelpDesk.Helpers
{
    using Microsoft.EntityFrameworkCore;
    using System.Net.NetworkInformation;
    using UTSTalentHelpDesk.Models.ComplexTypes;
    using UTSTalentHelpDesk.Models.Models;
    using UTSTalentHelpDesk.Models.ViewModels;
    public class EmailDatabaseContentProvider
    {
        #region Variables
        private static UTSTalentHelpDeskDBConnection _UTSTalentHelpDeskDBConnection;
        public long SalesUserId = 0;
        #endregion

        #region Constrcutor
        public EmailDatabaseContentProvider(UTSTalentHelpDeskDBConnection UTSTalentHelpDeskDBConnection)
        {
            _UTSTalentHelpDeskDBConnection = UTSTalentHelpDeskDBConnection;
        }
        #endregion

        //public EmailForBookTimeSlotModel GetEmailForBookTimeSlotModel(long talentId, long InvoiceId = 0, long OnboardID = 0, bool replacement = false, long HRID = 0, long contactid = 0, long shortlistedid = 0)
        //{
        //    EmailForBookTimeSlotModel emailForBookTimeSlotModel = new EmailForBookTimeSlotModel();
        //    if (talentId > 0)
        //    {
        //        GenTalent gen_Talent = _UTSTalentHelpDeskDBConnection.GenTalents.AsNoTracking().FirstOrDefault(x => x.Id == talentId);
        //        //_UTSTalentHelpDeskDBConnection.Entry(gen_Talent).Reload();
        //        if (gen_Talent != null)
        //        {
        //            emailForBookTimeSlotModel.TalentName = gen_Talent.Name;
        //            emailForBookTimeSlotModel.TalentFirstName = gen_Talent.FirstName;
        //            emailForBookTimeSlotModel.TalentLastName = gen_Talent.LastName;
        //            emailForBookTimeSlotModel.TalentEmail = gen_Talent.EmailId;
        //            emailForBookTimeSlotModel.Designation = gen_Talent.Designation;
        //            emailForBookTimeSlotModel.RoleID = gen_Talent.RoleId;
        //            emailForBookTimeSlotModel.finalCost = gen_Talent.FinalCost;
        //            emailForBookTimeSlotModel.CurrentCTC = gen_Talent.CurrentCtc;
        //            emailForBookTimeSlotModel.yearsofExperience = gen_Talent.TotalExpYears;
        //            emailForBookTimeSlotModel.TypeofDeveloper = gen_Talent.TypeofDeveloper;
        //            //emailForBookTimeSlotModel.IsTalentNotificationSend = gen_Talent.IsTalentNotificationSend ?? false;
        //            emailForBookTimeSlotModel.IsTalentNotificationSend = false;
        //            emailForBookTimeSlotModel.IsResetPasswordForTalent = gen_Talent.IsResetPassword ?? false;

        //            PrgTalentRole roles = _UTSTalentHelpDeskDBConnection.PrgTalentRoles.AsNoTracking().FirstOrDefault(x => x.Id == gen_Talent.RoleId);
        //            //_UTSTalentHelpDeskDBConnection.Entry(roles).Reload();

        //            if (roles != null)
        //            {
        //                emailForBookTimeSlotModel.TalentRole = roles.TalentRole;
        //            }

        //            PrgTalentStatusAfterClientSelection talentStatus_AfterClientSelection = _UTSTalentHelpDeskDBConnection.PrgTalentStatusAfterClientSelections.AsNoTracking().FirstOrDefault(x => x.Id == gen_Talent.TalentStatusIdAfterClientSelection);
        //            //_UTSTalentHelpDeskDBConnection.Entry(talentStatus_AfterClientSelection).Reload();

        //            if (talentStatus_AfterClientSelection != null)
        //            {
        //                emailForBookTimeSlotModel.talentStatusAfterClientSelection = talentStatus_AfterClientSelection.TalentStatus;
        //            }

        //            PrgTalentType Type = _UTSTalentHelpDeskDBConnection.PrgTalentTypes.AsNoTracking().Where(x => x.Id == gen_Talent.TalentTypeId).FirstOrDefault();
        //            //_UTSTalentHelpDeskDBConnection.Entry(Type).Reload();
        //            emailForBookTimeSlotModel.TalentType = Type != null ? Type.TalentType : string.Empty;
        //        }
        //    }
        //    if (HRID > 0)
        //    {
        //        GenSalesHiringRequest salesHiringRequest = _UTSTalentHelpDeskDBConnection.GenSalesHiringRequests.AsNoTracking().FirstOrDefault(x => x.Id == HRID);
        //        //_UTSTalentHelpDeskDBConnection.Entry(salesHiringRequest).Reload();
        //        if (salesHiringRequest != null)
        //        {
        //            var userobject = _UTSTalentHelpDeskDBConnection.UsrUsers.AsNoTracking().FirstOrDefault(x => x.Id == salesHiringRequest.SalesUserId);
        //            if (userobject != null)
        //            {
        //                emailForBookTimeSlotModel.HRSalesPersonID = userobject.Id;
        //                emailForBookTimeSlotModel.salesName = userobject.FullName;
        //                emailForBookTimeSlotModel.salesemailid = userobject.EmailId;
        //            }
        //            emailForBookTimeSlotModel.HR_Number = salesHiringRequest.HrNumber;
        //            emailForBookTimeSlotModel.position = salesHiringRequest.RequestForTalent;
        //            emailForBookTimeSlotModel.IsManaged = salesHiringRequest.IsManaged;
        //            emailForBookTimeSlotModel.IsAdHoc = salesHiringRequest.IsAdHocHr;
        //            emailForBookTimeSlotModel.DPPercentage = salesHiringRequest.Dppercentage;
        //            emailForBookTimeSlotModel.Discovery_Call = salesHiringRequest.DiscoveryCall;

        //            SalesUserId = salesHiringRequest.SalesUserId.Value;

        //            //new status change
        //            Sproc_UTS_Get_HRStatus_Result result = _UTSTalentHelpDeskDBConnection.Set<Sproc_UTS_Get_HRStatus_Result>().FromSqlRaw(String.Format("{0} {1}", Constants.ProcConstant.Sproc_UTS_Get_HRStatus, salesHiringRequest.Id)).AsEnumerable().FirstOrDefault();
        //            if (result != null)
        //            {
        //                emailForBookTimeSlotModel.HRStatus = result.HRStatus;
        //            }
        //        }

        //        GenContact contact = null;

        //        if (salesHiringRequest != null)
        //            contact = _UTSTalentHelpDeskDBConnection.GenContacts.AsNoTracking().FirstOrDefault(x => x.Id == salesHiringRequest.ContactId);
        //        //_UTSTalentHelpDeskDBConnection.Entry(contact).Reload();

        //        if (contact != null)
        //        {
        //            emailForBookTimeSlotModel.clientName = contact.FullName;
        //            emailForBookTimeSlotModel.Username = contact.EmailId;
        //            emailForBookTimeSlotModel.ClientEmail = contact.EmailId;
        //            //emailForBookTimeSlotModel.Password = string.Format("{0}@123", contact.FirstName.ToLower());
        //            emailForBookTimeSlotModel.Password = "Uplers@123";
        //            emailForBookTimeSlotModel.IsResetPassword = Convert.ToBoolean(contact.IsResetPassword);
        //            //emailForBookTimeSlotModel.IsClientNotificationSend = contact.IsClientNotificationSend;
        //            emailForBookTimeSlotModel.IsClientNotificationSend = false;

        //            GenCompany company = _UTSTalentHelpDeskDBConnection.GenCompanies.AsNoTracking().FirstOrDefault(x => x.Id == contact.CompanyId);
        //            //_UTSTalentHelpDeskDBConnection.Entry(company).Reload();
        //            if (company != null)
        //            {
        //                emailForBookTimeSlotModel.CompanyName = company.Company;
        //                var AM_SalesPerson = _UTSTalentHelpDeskDBConnection.UsrUsers.AsNoTracking().Where(x => x.Id == company.AmSalesPersonId).FirstOrDefault();
        //                if (AM_SalesPerson != null)
        //                {
        //                    emailForBookTimeSlotModel.AM_SalesPersonID = AM_SalesPerson.Id;
        //                    emailForBookTimeSlotModel.AM_SalesPersonName = AM_SalesPerson.FullName;
        //                    emailForBookTimeSlotModel.AM_SalesPersonEmailID = AM_SalesPerson.EmailId;
        //                }
        //                var NBD_SalesPerson = _UTSTalentHelpDeskDBConnection.UsrUsers.AsNoTracking().Where(x => x.Id == company.NbdSalesPersonId).FirstOrDefault();
        //                if (NBD_SalesPerson != null)
        //                {
        //                    emailForBookTimeSlotModel.NBD_SalesPersonID = NBD_SalesPerson.Id;
        //                    emailForBookTimeSlotModel.NBD_SalesPersonName = NBD_SalesPerson.FullName;
        //                    emailForBookTimeSlotModel.NBD_SalesPersonEmailID = NBD_SalesPerson.EmailId;
        //                }
        //                UsrUserHierarchy usr_UserHierarchy = new UsrUserHierarchy();
        //                usr_UserHierarchy = _UTSTalentHelpDeskDBConnection.UsrUserHierarchies.Where(x => x.UserId == company.AmSalesPersonId).FirstOrDefault();

        //                if (usr_UserHierarchy != null)
        //                {
        //                    var AM_AssignedSalesManager = _UTSTalentHelpDeskDBConnection.UsrUsers.AsNoTracking().Where(x => x.Id == usr_UserHierarchy.ParentId).FirstOrDefault();
        //                }
        //            }
        //        }
        //    }
        //    if (talentId > 0 && HRID > 0)
        //    {
        //        GenContactTalentPriority ContactTalentPriority = _UTSTalentHelpDeskDBConnection.GenContactTalentPriorities.AsNoTracking().FirstOrDefault(x => x.TalentId == talentId && x.HiringRequestId == HRID);
        //        //_UTSTalentHelpDeskDBConnection.Entry(ContactTalentPriority).Reload();
        //        if (ContactTalentPriority != null)
        //        {
        //            emailForBookTimeSlotModel.priority = ContactTalentPriority.TalentPriority;
        //        }
        //        GenTalentPointofContact talentPointofContact = _UTSTalentHelpDeskDBConnection.GenTalentPointofContacts.AsNoTracking().FirstOrDefault(x => x.TalentId == talentId);
        //        //_UTSTalentHelpDeskDBConnection.Entry(talentPointofContact).Reload();
        //        if (talentPointofContact != null)
        //        {
        //            UsrUser Userdetail = _UTSTalentHelpDeskDBConnection.UsrUsers.AsNoTracking().FirstOrDefault(x => x.Id == talentPointofContact.UserId);
        //            //_UTSTalentHelpDeskDBConnection.Entry(Userdetail).Reload();
        //            if (Userdetail != null)
        //            {
        //                emailForBookTimeSlotModel.TalentSuccessEmail = Userdetail.EmailId;
        //            }
        //        }
        //    }
        //    if (contactid > 0)
        //    {
        //        GenContact contact = _UTSTalentHelpDeskDBConnection.GenContacts.AsNoTracking().FirstOrDefault(x => x.Id == contactid);
        //        //_UTSTalentHelpDeskDBConnection.Entry(contact).Reload();
        //        if (contact != null)
        //        {
        //            emailForBookTimeSlotModel.clientName = contact.FullName;
        //            emailForBookTimeSlotModel.Username = contact.EmailId;
        //            emailForBookTimeSlotModel.ClientEmail = contact.EmailId;
        //            //emailForBookTimeSlotModel.Password = string.Format("{0}@123", contact.FirstName.ToLower());
        //            emailForBookTimeSlotModel.Password = "Uplers@123";
        //            emailForBookTimeSlotModel.IsResetPassword = Convert.ToBoolean(contact.IsResetPassword);
        //            //emailForBookTimeSlotModel.IsClientNotificationSend = contact.IsClientNotificationSend;
        //            emailForBookTimeSlotModel.IsClientNotificationSend = false;
        //        }
        //        GenCompany company = _UTSTalentHelpDeskDBConnection.GenCompanies.AsNoTracking().FirstOrDefault(x => x.Id == contact.CompanyId);
        //        //_UTSTalentHelpDeskDBConnection.Entry(company).Reload();
        //        emailForBookTimeSlotModel.CompanyName = company.Company;

        //    }

        //    if (shortlistedid > 0)
        //    {
        //        List<GenSalesHiringRequestInterviewerDetail> salesHiringRequest_InterviewerDetails = (from shi in _UTSTalentHelpDeskDBConnection.GenSalesHiringRequestInterviewerDetails.AsNoTracking()
        //                                                                                              join tsi in _UTSTalentHelpDeskDBConnection.GenTalentSelectedInterviewerDetails.AsNoTracking() on shi.Id equals tsi.InterviewerId
        //                                                                                              where shi.HiringRequestId == HRID && tsi.ShortlistedInterviewId == shortlistedid
        //                                                                                              select shi).ToList();
        //        if (salesHiringRequest_InterviewerDetails.Any())
        //        {
        //            List<string> InterviewerList = new List<string>();
        //            string InterviewerName;
        //            for (int i = 0; i < salesHiringRequest_InterviewerDetails.Count(); i++)
        //            {
        //                InterviewerName = salesHiringRequest_InterviewerDetails[i].InterviewerName;
        //                if (!string.IsNullOrEmpty(InterviewerName))
        //                {
        //                    InterviewerList.Add(InterviewerName);
        //                }
        //            }
        //            emailForBookTimeSlotModel.Interviewer = string.Join(", ", InterviewerList);
        //        }
        //    }

        //    if (InvoiceId > 0 && OnboardID > 0)
        //    {
        //        var InvoiceDetail = _UTSTalentHelpDeskDBConnection.GenPayoutInformations.AsNoTracking().FirstOrDefault(x => x.EsalesInvoiceId == InvoiceId && x.OnBoardId == OnboardID);
        //        if (InvoiceDetail != null)
        //        {
        //            emailForBookTimeSlotModel.InvoiceAmount = InvoiceDetail.EsalesInvoiceAmount ?? 0;
        //            emailForBookTimeSlotModel.InvoiceNumber = InvoiceDetail.EsalesInvoiceNumber;
        //            emailForBookTimeSlotModel.InvoiceCreationDate = InvoiceDetail.EsalesInvoiceDate.HasValue ? InvoiceDetail.EsalesInvoiceDate.ToString() : "";
        //        }
        //    }

        //    var OnBoardDetail = _UTSTalentHelpDeskDBConnection.GenOnBoardTalents.AsNoTracking().FirstOrDefault(x => x.Id == OnboardID);
        //    if (OnBoardDetail != null)
        //    {
        //        emailForBookTimeSlotModel.EngagementID = OnBoardDetail.EngagemenId;
        //        var salesHiringRequest = _UTSTalentHelpDeskDBConnection.GenSalesHiringRequests.AsNoTracking().FirstOrDefault(x => x.Id == OnBoardDetail.HiringRequestId);
        //        if (salesHiringRequest != null)
        //        {
        //            emailForBookTimeSlotModel.IsManaged = salesHiringRequest.IsManaged;
        //            emailForBookTimeSlotModel.SalesUserName = _UTSTalentHelpDeskDBConnection.UsrUsers.FirstOrDefault(x => x.Id == salesHiringRequest.SalesUserId).FullName;
        //            emailForBookTimeSlotModel.SalesUseEMail = _UTSTalentHelpDeskDBConnection.UsrUsers.FirstOrDefault(x => x.Id == salesHiringRequest.SalesUserId).EmailId;
        //        }
        //        var HRdetail = _UTSTalentHelpDeskDBConnection.GenSalesHiringRequestDetails.AsNoTracking().FirstOrDefault(x => x.HiringRequestId == OnBoardDetail.HiringRequestId);
        //        if (HRdetail != null)
        //        {
        //            emailForBookTimeSlotModel.Currancy = HRdetail.Currency;
        //        }
        //    }

        //    if (replacement)
        //    {
        //        var ReplacementDetail = _UTSTalentHelpDeskDBConnection.GenOnBoardTalentsReplacementDetails.AsNoTracking().FirstOrDefault(x => x.OnboardId == OnboardID && x.OldTalentId == talentId);
        //        if (ReplacementDetail != null)
        //        {
        //            emailForBookTimeSlotModel.Reason = ReplacementDetail.ReplacementReason;
        //        }
        //    }

        //    return emailForBookTimeSlotModel;
        //}

        public string GetPrgContactTimeZone(string timezone)
        {
            string Description = string.Empty;

            PrgContactTimeZone prgContactTimeZone = _UTSTalentHelpDeskDBConnection.PrgContactTimeZones.AsNoTracking().FirstOrDefault(x => x.TimeZoneTitle == timezone && x.IsActive == true);

            if (prgContactTimeZone != null)
            {
                Description = prgContactTimeZone.TimeZoneTitle;
            }

            return Description;
        }

        public string GetCCEmailIdValues()
        {
            string CCEmailIds = "";
            string SalesLeadEmailId = "";

            if (SalesUserId > 0)
            {
                UsrUserHierarchy _objUserHierarchy = _UTSTalentHelpDeskDBConnection.UsrUserHierarchies.AsNoTracking().Where(x => x.UserId == SalesUserId).FirstOrDefault();
                //_UTSTalentHelpDeskDBConnection.Entry(_objUserHierarchy).Reload();
                if (_objUserHierarchy != null)
                {
                    var result = _UTSTalentHelpDeskDBConnection.UsrUsers.AsNoTracking().FirstOrDefault(x => x.Id == _objUserHierarchy.ParentId);
                    SalesLeadEmailId = result != null ? result.EmailId : String.Empty;
                }
            }

            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().FirstOrDefault(x => x.Key == "EmailId" && x.IsActive == true);
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                if (SalesLeadEmailId != "")
                    CCEmailIds = "," + _objSystemConfigurationName.Value + "," + SalesLeadEmailId;
                else
                    CCEmailIds = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailIds;
        }

        public PrgTalentRejectReason GetPrgTalentRejectReason(int id)
        {
            var reason = _UTSTalentHelpDeskDBConnection.PrgTalentRejectReasons.Where(x => x.Id == id).FirstOrDefault();
            return reason;
        }
        public string GetCCEmailNameValues()
        {
            string CCEmailNames = "";
            string SalesLeadName = "";

            if (SalesUserId > 0)
            {
                UsrUserHierarchy _objUserHierarchy = _UTSTalentHelpDeskDBConnection.UsrUserHierarchies.AsNoTracking().Where(x => x.UserId == SalesUserId).FirstOrDefault();
                //_UTSTalentHelpDeskDBConnection.Entry(_objUserHierarchy).Reload();
                if (_objUserHierarchy != null)
                {
                    var result = _UTSTalentHelpDeskDBConnection.UsrUsers.AsNoTracking().FirstOrDefault(x => x.Id == _objUserHierarchy.ParentId);
                    SalesLeadName = result != null ? result.FullName : string.Empty;
                }
            }


            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().FirstOrDefault(x => x.Key == "Name" && x.IsActive == true);
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                if (SalesLeadName != "")
                    CCEmailNames = "," + _objSystemConfigurationName.Value + "," + SalesLeadName;
                else
                    CCEmailNames = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailNames;
        }

        public string GetCCEmailIdValues(string emailType = "AdhocCCEmailIds")
        {
            string CCEmailIds = "";
            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().Where(x => x.Key == emailType && x.IsActive == true).FirstOrDefault();
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                CCEmailIds = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailIds;
        }

        public string GetCCEmailNameValues(string emailType = "AdhocCCEmailName")
        {
            string CCEmailNames = "";
            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().Where(x => x.Key == emailType && x.IsActive == true).FirstOrDefault();
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                CCEmailNames = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailNames;
        }

        public List<GenContactPointofContact> getPointOfContact(long? contactid)
        {
            return _UTSTalentHelpDeskDBConnection.GenContactPointofContacts.AsNoTracking().Where(x => x.ContactId == contactid).OrderBy(x => x.Id).ToList();
        }

        public UsrUser getUserObject(long userid)
        {
            return _UTSTalentHelpDeskDBConnection.UsrUsers.AsNoTracking().FirstOrDefault(x => x.Id == userid);
        }

        public static string GetAdHocCCEmailIdValues()
        {
            string CCEmailIds = "";
            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().FirstOrDefault(x => x.Key == "AdhocCCEmailIds" && x.IsActive == true);
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                CCEmailIds = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailIds;
        }
        

        public static string GetAdHocCCEmailNameValues()
        {
            string CCEmailNames = "";
            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().FirstOrDefault(x => x.Key == "AdhocCCEmailName" && x.IsActive == true);
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                CCEmailNames = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailNames;
        }

        public static string GetSMCCEmailNameValues()
        {
            string CCEmailNames = "";
            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().FirstOrDefault(x => x.Key == "SMCCEmailNames" && x.IsActive == true);
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                CCEmailNames = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailNames;
        }

        public static string GetManagedCCEmailIdValues()
        {
            string CCEmailIds = "";
            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().FirstOrDefault(x => x.Key == "ManagedCCEmailIds" && x.IsActive == true);
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                CCEmailIds = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailIds;
        }
        public static string GetManagedCCEmailNameValues()
        {
            string CCEmailNames = "";
            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().FirstOrDefault(x => x.Key == "ManagedCCEmailNames" && x.IsActive == true);
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                CCEmailNames = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailNames;
        }

        public static string GetSMCCEmailIdValues()
        {
            string SMCCEmailIds = "";
            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().FirstOrDefault(x => x.Key == "SMCCEmailIds" && x.IsActive == true);
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                SMCCEmailIds = "," + _objSystemConfigurationName.Value;
            }

            return SMCCEmailIds;
        }

        public string GetCCHRBuddyNameValues()
        {
            string CCEmailNames = "";

            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().Where(x => x.Key == "HRBuddyName" && x.IsActive == true).FirstOrDefault();
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                CCEmailNames = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailNames;
        }
        public string GetCCHRBuddyEmailValues()
        {
            string CCEmailIds = "";


            GenSystemConfiguration _objSystemConfigurationName = _UTSTalentHelpDeskDBConnection.GenSystemConfigurations.AsNoTracking().Where(x => x.Key == "HRBuddyEmail" && x.IsActive == true).FirstOrDefault();
            //_UTSTalentHelpDeskDBConnection.Entry(_objSystemConfigurationName).Reload();
            if (_objSystemConfigurationName != null)
            {
                CCEmailIds = "," + _objSystemConfigurationName.Value;
            }

            return CCEmailIds;
        }
    }
}
