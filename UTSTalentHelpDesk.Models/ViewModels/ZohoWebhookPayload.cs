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
        [JsonProperty("payload")]
        public PayloadDetails Payload { get; set; }
        [JsonProperty("eventTime")]
        public string EventTime { get; set; }
        [JsonProperty("eventType")]
        public string EventType { get; set; }
        [JsonProperty("orgId")]
        public string OrgId { get; set; }

        public class PayloadDetails
        {
            // Ticket Identification
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("ticketNumber")]
            public string TicketNumber { get; set; }
            [JsonProperty("subject")]
            public string Subject { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }

            // Ticket Metadata
            [JsonProperty("modifiedTime")]
            public DateTime ModifiedTime { get; set; }
            [JsonProperty("createdTime")]
            public DateTime CreatedTime { get; set; }
            [JsonProperty("status")]
            public string Status { get; set; }
            [JsonProperty("statusType")]
            public string StatusType { get; set; }
            [JsonProperty("priority")]
            public string Priority { get; set; }
            [JsonProperty("category")]
            public string Category { get; set; }
            [JsonProperty("subCategory")]
            public string SubCategory { get; set; }
            [JsonProperty("channel")]

            // Channel and Source Information
            public string Channel { get; set; }
            [JsonProperty("channelCode")]
            public string ChannelCode { get; set; }
            [JsonProperty("source")]
            public SourceDetails Source { get; set; }

            // Contact Information
            [JsonProperty("contact")]
            public ContactDetails Contact { get; set; }
            [JsonProperty("contactId")]
            public string ContactId { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("phone")]
            public string Phone { get; set; }

            // Assignee Details
            [JsonProperty("assignee")]
            public AssigneeDetails Assignee { get; set; }
            [JsonProperty("assigneeId")]
            public string AssigneeId { get; set; }

            // Ticket Flags and Statuses
            [JsonProperty("isOverDue")]
            public bool IsOverDue { get; set; }
            [JsonProperty("isTrashed")]
            public bool IsTrashed { get; set; }
            [JsonProperty("isResponseOverDue")]
            public bool IsResponseOverDue { get; set; }
            [JsonProperty("isSpam")]
            public bool IsSpam { get; set; }
            [JsonProperty("isArchived")]
            public bool IsArchived { get; set; }
            [JsonProperty("isDeleted")]
            public bool IsDeleted { get; set; }
            [JsonProperty("isEscalated")]
            public bool IsEscalated { get; set; }
            [JsonProperty("isFollowing")]
            public bool IsFollowing { get; set; }

            // Counts and Tracking
            [JsonProperty("threadCount")]
            public string ThreadCount { get; set; }
            [JsonProperty("commentCount")]
            public string CommentCount { get; set; }
            [JsonProperty("taskCount")]
            public string TaskCount { get; set; }
            [JsonProperty("approvalCount")]
            public string ApprovalCount { get; set; }
            [JsonProperty("attachmentCount")]
            public string AttachmentCount { get; set; }
            [JsonProperty("followerCount")]
            public string FollowerCount { get; set; }
            [JsonProperty("tagCount")]
            public string TagCount { get; set; }

            // Additional Details
            [JsonProperty("dueDate")]
            public DateTime? DueDate { get; set; }
            [JsonProperty("closedTime")]
            public DateTime? ClosedTime { get; set; }
            [JsonProperty("customerResponseTime")]
            public DateTime? CustomerResponseTime { get; set; }
            [JsonProperty("responseDueDate")]
            public DateTime? ResponseDueDate { get; set; }
            [JsonProperty("lastActivityTime")]
            public DateTime? LastActivityTime { get; set; }

            // Layout and Department
            [JsonProperty("departmentId")]
            public string DepartmentId { get; set; }
            [JsonProperty("teamId")]
            public string TeamId { get; set; }
            [JsonProperty("productId")]
            public string ProductId { get; set; }
            [JsonProperty("accountId")]
            public string AccountId { get; set; }
            [JsonProperty("layoutDetails")]
            public LayoutDetails LayoutDetails { get; set; }

            // Custom Fields
            [JsonProperty("customField")]
            public CustomFields CustomField { get; set; }
            //public CustomFields Cf { get; set; }

            // Attachments
            [JsonProperty("descAttachments")]
            public List<DescriptionAttachment> DescAttachments { get; set; }

            // Web URL
            [JsonProperty("webUrl")]
            public string WebUrl { get; set; }

            // Miscellaneous
            [JsonProperty("sentiment")]
            public string Sentiment { get; set; }
            [JsonProperty("language")]
            public string Language { get; set; }
            [JsonProperty("secondaryContacts")]
            public List<string> SecondaryContacts { get; set; }
            [JsonProperty("entitySkills")]
            public List<string> EntitySkills { get; set; }
            [JsonProperty("sharedDepartments")]
            public List<string> SharedDepartments { get; set; }
            [JsonProperty("onholdTime")]
            public string OnholdTime { get; set; }
            [JsonProperty("createdBy")]
            public string CreatedBy { get; set; }
            [JsonProperty("modifiedBy")]
            public string ModifiedBy { get; set; }
        }

        public class SourceDetails
        {
            [JsonProperty("appName")]
            public string AppName { get; set; }
            [JsonProperty("extId")]
            public string ExtId { get; set; }
            [JsonProperty("permalink")]
            public string Permalink { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("appPhotoURL")]
            public string AppPhotoURL { get; set; }
        }

        public class ContactDetails
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("firstName")]
            public string FirstName { get; set; }
            [JsonProperty("lastName")]
            public string LastName { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("phone")]
            public string Phone { get; set; }
            [JsonProperty("mobile")]
            public string Mobile { get; set; }
            [JsonProperty("isSpam")]
            public bool IsSpam { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("account")]
            public string Account { get; set; }
        }

        public class AssigneeDetails
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("firstName")]
            public string FirstName { get; set; }
            [JsonProperty("lastName")]
            public string LastName { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("photoURL")]
            public string PhotoURL { get; set; }
        }

        public class LayoutDetails
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("layoutName")]
            public string LayoutName { get; set; }
        }

        public class CustomFields
        {
            [JsonProperty("severityPercentage")]
            public string SeverityPercentage { get; set; }
            [JsonProperty("dateOfPurchase")]
            public DateTime? DateOfPurchase { get; set; }
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public class DescriptionAttachment
        {
            [JsonProperty("size")]
            public string Size { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("href")]
            public string Href { get; set; }
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        //public class PrevState
        //{
        //    public DateTime? ModifiedTime { get; set; }
        //    public string SubCategory { get; set; }
        //    public string StatusType { get; set; }
        //    public string Subject { get; set; }
        //    public string DepartmentId { get; set; }
        //    public DateTime? DueDate { get; set; }
        //    public string Channel { get; set; }
        //    public TimeSpan? OnholdTime { get; set; }
        //    public string Language { get; set; }
        //    public Source Source { get; set; }
        //    public string Resolution { get; set; }
        //    public List<string> SharedDepartments { get; set; }
        //    public DateTime? ClosedTime { get; set; }
        //    public string ApprovalCount { get; set; }
        //    public bool IsOverDue { get; set; }
        //    public bool IsTrashed { get; set; }
        //    public Contact Contact { get; set; }
        //    public DateTime CreatedTime { get; set; }
        //    public string Id { get; set; }
        //    public bool IsResponseOverdue { get; set; }
        //    public string FirstThread { get; set; }
        //    public DateTime? CustomerResponseTime { get; set; }
        //    public string ProductId { get; set; }
        //    public string ContactId { get; set; }
        //    public string ThreadCount { get; set; }
        //    public List<string> SecondaryContacts { get; set; }
        //    public string Priority { get; set; }
        //    public string Classification { get; set; }
        //    public string CommentCount { get; set; }
        //    public string AccountId { get; set; }
        //    public string TaskCount { get; set; }
        //    public string Phone { get; set; }
        //    public string WebUrl { get; set; }
        //    public bool IsSpam { get; set; }
        //    public Assignee Assignee { get; set; }
        //    public DateTime? LastActivityTime { get; set; }
        //    public string Status { get; set; }
        //    public List<string> EntitySkills { get; set; }
        //    public string TicketNumber { get; set; }
        //    public string Sentiment { get; set; }
        //    public bool IsArchived { get; set; }
        //    public CustomFields CustomFields { get; set; }
        //    public string Description { get; set; }
        //    public string TimeEntryCount { get; set; }
        //    public string ChannelRelatedInfo { get; set; }
        //    public DateTime? ResponseDueDate { get; set; }
        //    public bool IsDeleted { get; set; }
        //    public string ModifiedBy { get; set; }
        //    public string FollowerCount { get; set; }
        //    public string Email { get; set; }
        //    public LayoutDetails LayoutDetails { get; set; }
        //    public string ChannelCode { get; set; }
        //    //public CustomFields CF { get; set; }
        //    public bool IsFollowing { get; set; }
        //    public string AssigneeId { get; set; }
        //    public string LayoutId { get; set; }
        //    public string CreatedBy { get; set; }
        //    public string TeamId { get; set; }
        //    public string TagCount { get; set; }
        //    public bool IsEscalated { get; set; }
        //    public string AttachmentCount { get; set; }
        //    public string Category { get; set; }
        //    public List<string> DescAttachments { get; set; }
        //}
    }
}
