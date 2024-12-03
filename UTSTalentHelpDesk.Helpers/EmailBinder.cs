﻿namespace UTSTalentHelpDesk.Helpers
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
    using static System.Net.Mime.MediaTypeNames;
    using static System.Net.WebRequestMethods;

    public class EmailBinder
    {
        #region Variables 
        IConfiguration _configuration;
        EmailDatabaseContentProvider emailDatabaseContentProvider;
        UTSTalentHelpDeskDBConnection _UTSTalentHelpDeskDBContext;
      
        List<string> CCEMAIL = new List<string>();
        List<string> CCEMAILNAME = new List<string>();
        string ccEmail = string.Empty;
        string ccEmailName = string.Empty;
        #endregion

        #region Constructor
        public EmailBinder(IConfiguration configuration, UTSTalentHelpDeskDBConnection UTSTalentHelpDeskDBContext)
        {
            _configuration = configuration;
            _UTSTalentHelpDeskDBContext = UTSTalentHelpDeskDBContext;

            emailDatabaseContentProvider = new EmailDatabaseContentProvider(_UTSTalentHelpDeskDBContext);
            ccEmail = _configuration["app_settings:CCEmailId"];
            ccEmailName = _configuration["app_settings:CCEmailName"];

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


        public string SendEmailForHRDeleteToInternalTeam(GenSalesHiringRequest? _SalesHiringRequest, string? userName, string? talentEmail)
        {
            try
            {
                string Subject = "", BodyCustom = "", companyName = "", ClientName = "", ClientEmail = "";
                StringBuilder sbBody = new StringBuilder();

                if (_SalesHiringRequest != null)
                {
                    var ContactId = _SalesHiringRequest.ContactId;
                    GenContact contact = _UTSTalentHelpDeskDBContext.GenContacts.Where(x => x.Id == ContactId).FirstOrDefault();

                    if (contact != null)
                    {
                        ClientName = contact.FullName;
                        ClientEmail = contact.EmailId;
                        GenCompany company = _UTSTalentHelpDeskDBContext.GenCompanies.Where(x => x.Id == contact.CompanyId).FirstOrDefault();

                        if (company != null)
                        {
                            companyName = company.Company;
                        }
                    }

                    BodyCustom = "Hello Team,";
                    sbBody.Append(BodyCustom);
                    sbBody.Append("<br/><br/>");
                    sbBody.Append("Greetings for the day!");
                    sbBody.Append("<br/><br/>");

                    Subject = $"Talent is removed from HR {_SalesHiringRequest.HrNumber}";
                    sbBody.Append($"The Talent <strong>{talentEmail}</strong> is removed from the {_SalesHiringRequest.HrNumber} by {userName}.");

                    sbBody.Append("&nbsp;Below are the required details:");
                    sbBody.Append("<div style='width:100%'>");
                    sbBody.Append("<br/>");
                    sbBody.Append("HR number: " + _SalesHiringRequest.HrNumber);
                    sbBody.Append("<br/>");
                    sbBody.Append("Job Title: " + _SalesHiringRequest.RequestForTalent);
                    sbBody.Append("<br/>");
                    sbBody.Append("Talent Email: " + talentEmail);
                    sbBody.Append("<br/>");
                    sbBody.Append($"Client: {ClientName} ({ClientEmail})");
                    sbBody.Append("<br/>");
                    sbBody.Append($"Company: {companyName}");
                    sbBody.Append("<br/>");
                    sbBody.Append("<br/>");
                    sbBody.Append("Thanks");
                    sbBody.Append("<br/>");
                    sbBody.Append("Uplers Talent Solutions Team");
                    sbBody.Append("<br/>");
                    sbBody.Append("</div>");

                    #region Variable
                    EmailOperator emailOperator = new EmailOperator(_configuration);
                    #endregion

                    emailOperator.SetToEmailWithComma(ccEmail, ccEmailName);
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


    }
}