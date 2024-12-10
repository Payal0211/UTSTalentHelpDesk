using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class ZohoTicketRequest
    {
        public List<string> cntitySkills { get; set; }
        public string cubCategory { get; set; }
        public RequestCustomFields cf { get; set; }
        public string productId { get; set; }
        public string contactId { get; set; }
        public string cubject { get; set; }
        public string cueDate { get; set; }
        public string departmentId { get; set; }
        public string channel { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string priority { get; set; }
        public string classification { get; set; }
        public string assigneeId { get; set; }
        public string phone { get; set; }
        public string category { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string accountId { get; set; }
        public string layoutId { get; set; }
        public List<string> uploads { get; set; }
    }
    public class RequestCustomFields
    {
        public string Cf_PermanentAddress { get; set; }
        public string Cf_DateOfPurchase { get; set; }
        public string Cf_Phone { get; set; }
        public string Cf_NumberOfItems { get; set; }
        public string Cf_Url { get; set; }
        public string Cf_SecondaryEmail { get; set; }
        public string Cf_SeverityPercentage { get; set; }
        public string Cf_ModelName { get; set; }
    }

    // Response Model
    public class ZohoTicketResponse
    {
        public List<string> EntitySkills { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string TicketNumber { get; set; }
        public string SubCategory { get; set; }
        public string StatusType { get; set; }
        public string Subject { get; set; }
        public DateTime DueDate { get; set; }
        public string DepartmentId { get; set; }
        public string Channel { get; set; }
        public object OnholdTime { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public SourceInfo Source { get; set; }
        public object Resolution { get; set; }
        public List<string> SharedDepartments { get; set; }
        public object ClosedTime { get; set; }
        public string SharedCount { get; set; }
        public string ApprovalCount { get; set; }
        public string TimeEntryCount { get; set; }
        public bool IsOverDue { get; set; }
        public object ChannelRelatedInfo { get; set; }
        public string IsDeleted { get; set; }
        public bool IsTrashed { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public object ChannelCode { get; set; }
        public DateTime CustomerResponseTime { get; set; }
        public RequestCustomFields Cf { get; set; }
        public object ProductId { get; set; }
        public string ContactId { get; set; }
        public string ThreadCount { get; set; }
        public string Priority { get; set; }
        public object Classification { get; set; }
        public string AssigneeId { get; set; }
        public string CommentCount { get; set; }
        public string TaskCount { get; set; }
        public string Phone { get; set; }
        public string WebUrl { get; set; }
        public string AttachmentCount { get; set; }
        public bool IsEscalated { get; set; }
        public bool IsSpam { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }

    public class SourceInfo
    {
        public string AppName { get; set; }
        public string ExtId { get; set; }
        public string Type { get; set; }
        public string Permalink { get; set; }
        public string AppPhotoURL { get; set; }
    }
}
