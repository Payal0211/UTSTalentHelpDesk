namespace UTSTalentHelpDesk.Helpers
{
    using Aspose.Words;
    using Aspose.Words.XAttr;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Org.BouncyCastle.Asn1.Crmf;
    using Org.BouncyCastle.Asn1.X509;
    using RestSharp;
    using System;
    using System.Globalization;
    using System.Net.Mail;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Web;
    using UTSTalentHelpDesk.Helpers;
    using UTSTalentHelpDesk.Helpers.Common;
    using UTSTalentHelpDesk.Models.ComplexTypes;
    using UTSTalentHelpDesk.Models.Models;
    using UTSTalentHelpDesk.Models.ViewModels;
    using UTSTalentHelpDesk.Repositories.Interfaces;
    using static System.Net.Mime.MediaTypeNames;
    using static System.Net.WebRequestMethods;

    public class EmailBinder
    {
        #region Variables 
        IConfiguration _configuration;             
        private readonly IEmail _iEmail;

        #endregion

        #region Constructor
        public EmailBinder(IConfiguration configuration, IEmail iEmail)
        {
            _configuration = configuration;           
            _iEmail = iEmail;
        }

        #endregion

        #region public Method

        public void BindEmailForError(List<string> toEmail, List<string> toEmailName, string subject, string body = "")
        {
            EmailOperator emailOperator = new EmailOperator(_configuration);

            #region SetParam
            emailOperator.SetToEmail(toEmail);
            emailOperator.SetToEmailName(toEmailName);
            emailOperator.SetSubject(subject);
            emailOperator.SetBody(body);
            #endregion

            if (!string.IsNullOrEmpty(subject))
                emailOperator.SendEmail(true);
        }


        public string SendEmailToClientWhenRequestedForLeave(LeaveRequestViewModel request)
        {
            try
            {              
                string? Subject = "", BodyCustom = "",  ClientName = "", ClientEmail = "";
                StringBuilder sbBody = new StringBuilder();

                var reactClientPortalURL = _configuration["ReactClientPortalURL"];

                TS_Sproc_Get_Talent_Contact_Details_Result? contact_Details_Result =  _iEmail.GetTalentContactDetails(request.TalentID.Value);

                if (contact_Details_Result != null)
                { 
                    ClientName = contact_Details_Result.FullName;
                    ClientEmail = "riya.a@uplers.in"; //contact_Details_Result.EmailID

                    BodyCustom = $"Hello {ClientName},";
                    sbBody.Append(BodyCustom);
                    sbBody.Append("<br/><br/>");
                    sbBody.Append("I hope this message finds you well.");
                    sbBody.Append("<br/><br/>");

                    if (!string.IsNullOrEmpty(request.LeaveID))
                    {
                        sbBody.Append($"Please ignore the previous leave request for {contact_Details_Result.TalentName}, below is the updated leave request");
                        sbBody.Append("<br/><br/>");
                    }

                    Subject = "Employee Leave Request Notification";

                    sbBody.Append($"I wanted to inform you that {contact_Details_Result.TalentName}, who has been working on your project, " +
                        $"has submitted a leave request for {request.LeaveDate.Value.ToString("dd/MM/yyyy")} - {request.LeaveEndDate.Value.ToString("dd/MM/yyyy")}. " +
                        $"During this period, {contact_Details_Result.TalentName} will be unavailable..");

                    sbBody.Append("<br/><br/>");

                    sbBody.Append("&nbsp;If there are any immediate concerns or requirements, please feel free to let us know, and we will arrange" +
                        " for an alternative point of contact or resources as needed.:");
                    sbBody.Append("<br/><br/>");
                    sbBody.Append("We appreciate your understanding and will keep you updated if there are any changes.");                    
                    sbBody.Append("<br/>");
                    sbBody.Append("<br/>");
                    sbBody.Append("Kindly click <a style='color:#232323;font-style:normal;font-weight:700;text-transform:uppercase;border:0;background:#FFDA30;padding:0 20px;font-size:14px;display:inline-block;text-align:center;border-radius:27px;line-height:40px;text-decoration:none;' class='link' href='" + reactClientPortalURL + "leavedetails?talentId=" + MyExtensions.Encrypt(request.TalentID?.ToString()) + "&contactId=" + MyExtensions.Encrypt(contact_Details_Result.ID.ToString()) + "' target='_blank'>here</a> to take action.");
                    sbBody.Append("<br/>");
                    sbBody.Append("<br/>");
                    sbBody.Append("Thanks");
                    sbBody.Append("<br/>");
                    sbBody.Append("Uplers Talent Solutions Team");
                    sbBody.Append("<br/>");                   

                    #region Variable
                    EmailOperator emailOperator = new EmailOperator(_configuration);
                    #endregion

                    List<string> toEmail = new List<string>
                    {
                        ClientEmail
                    };

                    List<string> toEmailName = new List<string>
                    {
                        ClientName
                    };

                    emailOperator.SetToEmail(toEmail);
                    emailOperator.SetToEmailName(toEmailName);
                    emailOperator.SetSubject(Subject);
                    emailOperator.SetBody(sbBody.ToString());

                    #region SendEmail
                    if (!string.IsNullOrEmpty(Subject))
                        emailOperator.SendEmail(false, false, false);
                    #endregion

                    return "Success";
                }
                else
                    return "error";
            }
            catch (Exception e) { return e.Message; }
        }

        #endregion

        #region Email to TalentSupport for Zoho-ticket

        public bool SendEmailToTalentSupportWhenTicketRaised(TicketRequestViewModel request)
        {
            try
            {
                string? Subject = "", BodyCustom = "", ClientName = "riya.a@uplers.in", ClientEmail = "Riya Agarwal";
                StringBuilder sbBody = new StringBuilder();
              
                Subject = request.Subject;

                sbBody.Append(request.Description);

                sbBody.Append("<br/><br/>");
                
                sbBody.Append("<br/>");
                sbBody.Append("<br/>");
                sbBody.Append("Thanks");
                sbBody.Append("<br/>");                

                #region Variable
                EmailOperator emailOperator = new EmailOperator(_configuration);
                #endregion

                List<string> toEmail = new List<string>
                {
                        ClientEmail
                };

                List<string> toEmailName = new List<string>
                {
                        ClientName
                };

                emailOperator.SetToEmail(toEmail);
                emailOperator.SetToEmailName(toEmailName);
                emailOperator.SetSubject(Subject);
                emailOperator.SetBody(sbBody.ToString());

                #region SendEmail
                if (!string.IsNullOrEmpty(Subject))
                    emailOperator.SendEmail(false, false, false);
                #endregion

                return true;
            }
            catch (Exception e) { return false; }
        }

        #endregion
    }
}