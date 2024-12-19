using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UTSTalentHelpDesk.Models.ViewModels.ZohoWebhookPayload;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class ZohoWebhookPayload
    {
        public PayloadDetails Payload { get; set; }
        public PrevStateDetails PrevState { get; set; }
        public long EventTime { get; set; }
        public string EventType { get; set; }
        public string OrgId { get; set; }
    }
    public class PrevStateDetails
    {
        public string ModifiedTime { get; set; }
        public string SubCategory { get; set; }
        public string StatusType { get; set; }
        public string Subject { get; set; }
        public string DepartmentId { get; set; }
        public string DueDate { get; set; }
        public string Channel { get; set; }
        public string OnholdTime { get; set; }
        public string Language { get; set; }
        public SourceDetail Source { get; set; }
        public string Resolution { get; set; }
        public List<object> SharedDepartments { get; set; }
        public string ClosedTime { get; set; }
        public string ApprovalCount { get; set; }
        public bool IsOverDue { get; set; }
        public bool IsTrashed { get; set; }
        public ContactDetails Contact { get; set; }
        public string CreatedTime { get; set; }
        public string Id { get; set; }
        public bool IsResponseOverdue { get; set; }
        //public object FirstThread { get; set; }
        public string CustomerResponseTime { get; set; }
        //public object ProductId { get; set; }
        public string ContactId { get; set; }
        public string ThreadCount { get; set; }
        //public List<object> SecondaryContacts { get; set; }
        public string Priority { get; set; }
        public string Classification { get; set; }
        public string CommentCount { get; set; }
        //public object AccountId { get; set; }
        public string TaskCount { get; set; }
        public string Phone { get; set; }
        public string WebUrl { get; set; }
        public bool IsSpam { get; set; }
        public AssigneeDetails Assignee { get; set; }
        public string LastActivityTime { get; set; }
        public string Status { get; set; }
        public List<object> EntitySkills { get; set; }
        public string TicketNumber { get; set; }
        public object Sentiment { get; set; }
        public bool IsArchived { get; set; }
        public customFields CustomFields { get; set; }
        //public object Description { get; set; }
        public string TimeEntryCount { get; set; }
        //public object ChannelRelatedInfo { get; set; }
        public string ResponseDueDate { get; set; }
        public bool IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public string FollowerCount { get; set; }
        public string Email { get; set; }
        public LayoutDetails LayoutDetails { get; set; }
        public string ChannelCode { get; set; }
        public Dictionary<string, string> Cf { get; set; }
        public bool IsFollowing { get; set; }
        public string AssigneeId { get; set; }
        public string LayoutId { get; set; }
        public string CreatedBy { get; set; }
        //public object TeamId { get; set; }
        public string TagCount { get; set; }
        public bool IsEscalated { get; set; }
        public string AttachmentCount { get; set; }
        public string Category { get; set; }
        public List<object> DescAttachments { get; set; }
    }


    public class PayloadDetails
    {
        public string ModifiedTime { get; set; }
        public string SubCategory { get; set; }
        public string StatusType { get; set; }
        public string Subject { get; set; }
        public string DueDate { get; set; }
        public string DepartmentId { get; set; }
        public string Channel { get; set; }
        public string OnholdTime { get; set; }
        public string Language { get; set; }
        public SourceDetail Source { get; set; }
        public string Resolution { get; set; }
        public List<object> SharedDepartments { get; set; }
        public string ClosedTime { get; set; }
        public string ApprovalCount { get; set; }
        public bool IsOverDue { get; set; }
        public bool IsTrashed { get; set; }
        public ContactDetails Contact { get; set; }
        public string CreatedTime { get; set; }
        public string Id { get; set; }
        public bool IsResponseOverdue { get; set; }
        public string CustomerResponseTime { get; set; }
        //public string FirstThread { get; set; }
        public string ProductId { get; set; }
        public string ContactId { get; set; }
        public string ThreadCount { get; set; }
        public List<object> SecondaryContacts { get; set; }
        public string Priority { get; set; }
        public string Classification { get; set; }
        public string CommentCount { get; set; }
        public string TaskCount { get; set; }
        public string AccountId { get; set; }
        public string Phone { get; set; }
        public string WebUrl { get; set; }
        public AssigneeDetails Assignee { get; set; }
        public bool IsSpam { get; set; }
        public string Status { get; set; }
        public List<object> EntitySkills { get; set; }
        public string TicketNumber { get; set; }
        public string Sentiment { get; set; }
        public bool IsArchived { get; set; }
        public string Description { get; set; }
        public string TimeEntryCount { get; set; }
        public string ChannelRelatedInfo { get; set; }
        public string ResponseDueDate { get; set; }
        public bool IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public string FollowerCount { get; set; }
        public string Email { get; set; }
        public LayoutDetails LayoutDetails { get; set; }
        public string ChannelCode { get; set; }
        public customFields Cf { get; set; }
        public string LayoutId { get; set; }
        public string AssigneeId { get; set; }
        public string CreatedBy { get; set; }
        public string TeamId { get; set; }
        public string TagCount { get; set; }
        public string AttachmentCount { get; set; }
        public bool IsEscalated { get; set; }
        public string Category { get; set; }
        public List<object> DescAttachments { get; set; }
    }

    public class SourceDetail
    {
        public string AppName { get; set; }
        public string ExtParentId { get; set; }
        public string ExtId { get; set; }
        public string Permalink { get; set; }
        public string Type { get; set; }
        public string AppPhotoURL { get; set; }
    }

    public class ContactDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Id { get; set; }
        public bool IsSpam { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }
    }

    public class AccountDetails
    {
        public string Website { get; set; }
        public string AccountName { get; set; }
        public string Id { get; set; }
    }

    public class AssigneeDetails
    {
        public string PhotoURL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
    }

    public class LayoutDetails
    {
        public string Id { get; set; }
        public string LayoutName { get; set; }
    }
    public class customFields
    {
        [JsonProperty("severityPercentage")]
        public string SeverityPercentage { get; set; }
        [JsonProperty("dateOfPurchase")]
        public DateTime? DateOfPurchase { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }

}
