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
        public string EventTime { get; set; }
        public string EventType { get; set; }
        public string OrgId { get; set; }

        public class PayloadDetails
        {
            // Ticket Identification
            public string Id { get; set; }
            public string TicketNumber { get; set; }
            public string Subject { get; set; }
            public string Description { get; set; }

            // Ticket Metadata
            public DateTime ModifiedTime { get; set; }
            public DateTime CreatedTime { get; set; }
            public string Status { get; set; }
            public string StatusType { get; set; }
            public string Priority { get; set; }
            public string Category { get; set; }
            public string SubCategory { get; set; }

            // Channel and Source Information
            public string Channel { get; set; }
            public string ChannelCode { get; set; }
            public SourceDetails Source { get; set; }

            // Contact Information
            public ContactDetails Contact { get; set; }
            public string ContactId { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }

            // Assignee Details
            public AssigneeDetails Assignee { get; set; }
            public string AssigneeId { get; set; }

            // Ticket Flags and Statuses
            public bool IsOverDue { get; set; }
            public bool IsTrashed { get; set; }
            public bool IsResponseOverDue { get; set; }
            public bool IsSpam { get; set; }
            public bool IsArchived { get; set; }
            public bool IsDeleted { get; set; }
            public bool IsEscalated { get; set; }
            public bool IsFollowing { get; set; }

            // Counts and Tracking
            public string ThreadCount { get; set; }
            public string CommentCount { get; set; }
            public string TaskCount { get; set; }
            public string ApprovalCount { get; set; }
            public string AttachmentCount { get; set; }
            public string FollowerCount { get; set; }
            public string TagCount { get; set; }

            // Additional Details
            public DateTime? DueDate { get; set; }
            public DateTime? ClosedTime { get; set; }
            public DateTime? CustomerResponseTime { get; set; }
            public DateTime? ResponseDueDate { get; set; }
            public DateTime? LastActivityTime { get; set; }

            // Layout and Department
            public string DepartmentId { get; set; }
            public string TeamId { get; set; }
            public string ProductId { get; set; }
            public string AccountId { get; set; }
            public LayoutDetails LayoutDetails { get; set; }

            // Custom Fields
            public CustomFields CustomFields { get; set; }
            public CustomFields Cf { get; set; }

            // Attachments
            public List<DescriptionAttachment> DescAttachments { get; set; }

            // Web URL
            public string WebUrl { get; set; }

            // Miscellaneous
            public string Sentiment { get; set; }
            public string Language { get; set; }
            public List<string> SecondaryContacts { get; set; }
            public List<string> EntitySkills { get; set; }
            public List<string> SharedDepartments { get; set; }
            public string OnholdTime { get; set; }
            public string CreatedBy { get; set; }
            public string ModifiedBy { get; set; }
        }

        public class SourceDetails
        {
            public string AppName { get; set; }
            public string ExtId { get; set; }
            public string Permalink { get; set; }
            public string Type { get; set; }
            public string AppPhotoURL { get; set; }
        }

        public class ContactDetails
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Mobile { get; set; }
            public bool IsSpam { get; set; }
            public string Type { get; set; }
            public string Account { get; set; }
        }

        public class AssigneeDetails
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhotoURL { get; set; }
        }

        public class LayoutDetails
        {
            public string Id { get; set; }
            public string LayoutName { get; set; }
        }

        public class CustomFields
        {
            public string SeverityPercentage { get; set; }
            public DateTime? DateOfPurchase { get; set; }
            public string Url { get; set; }
        }

        public class DescriptionAttachment
        {
            public string Size { get; set; }
            public string Name { get; set; }
            public string Href { get; set; }
            public string Id { get; set; }
        }

        public class PrevState
        {
            public DateTime? ModifiedTime { get; set; }
            public string SubCategory { get; set; }
            public string StatusType { get; set; }
            public string Subject { get; set; }
            public string DepartmentId { get; set; }
            public DateTime? DueDate { get; set; }
            public string Channel { get; set; }
            public TimeSpan? OnholdTime { get; set; }
            public string Language { get; set; }
            public Source Source { get; set; }
            public string Resolution { get; set; }
            public List<string> SharedDepartments { get; set; }
            public DateTime? ClosedTime { get; set; }
            public string ApprovalCount { get; set; }
            public bool IsOverDue { get; set; }
            public bool IsTrashed { get; set; }
            public Contact Contact { get; set; }
            public DateTime CreatedTime { get; set; }
            public string Id { get; set; }
            public bool IsResponseOverdue { get; set; }
            public string FirstThread { get; set; }
            public DateTime? CustomerResponseTime { get; set; }
            public string ProductId { get; set; }
            public string ContactId { get; set; }
            public string ThreadCount { get; set; }
            public List<string> SecondaryContacts { get; set; }
            public string Priority { get; set; }
            public string Classification { get; set; }
            public string CommentCount { get; set; }
            public string AccountId { get; set; }
            public string TaskCount { get; set; }
            public string Phone { get; set; }
            public string WebUrl { get; set; }
            public bool IsSpam { get; set; }
            public Assignee Assignee { get; set; }
            public DateTime? LastActivityTime { get; set; }
            public string Status { get; set; }
            public List<string> EntitySkills { get; set; }
            public string TicketNumber { get; set; }
            public string Sentiment { get; set; }
            public bool IsArchived { get; set; }
            public CustomFields CustomFields { get; set; }
            public string Description { get; set; }
            public string TimeEntryCount { get; set; }
            public string ChannelRelatedInfo { get; set; }
            public DateTime? ResponseDueDate { get; set; }
            public bool IsDeleted { get; set; }
            public string ModifiedBy { get; set; }
            public string FollowerCount { get; set; }
            public string Email { get; set; }
            public LayoutDetails LayoutDetails { get; set; }
            public string ChannelCode { get; set; }
            public CustomFields CF { get; set; }
            public bool IsFollowing { get; set; }
            public string AssigneeId { get; set; }
            public string LayoutId { get; set; }
            public string CreatedBy { get; set; }
            public string TeamId { get; set; }
            public string TagCount { get; set; }
            public bool IsEscalated { get; set; }
            public string AttachmentCount { get; set; }
            public string Category { get; set; }
            public List<string> DescAttachments { get; set; }
        }
    }
}
