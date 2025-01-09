using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{ 
    public class LastThread
    {
        public string channel { get; set; }
        public bool isDraft { get; set; }
        public bool isForward { get; set; }
        public string direction { get; set; }
    }

    public class ZohoTicketsRequest
    {
        public List<ZohoTicketsRequestDetails> Data { get; set; }
    }

    public class ZohoTicketsRequestDetails
    {
        public string? id { get; set; }
        public string? ticketNumber { get; set; }
        public string? layoutId { get; set; }
        public string? email { get; set; }
        public string phone { get; set; }
        public string? subject { get; set; }
        public string? status { get; set; }
        public string? statusType { get; set; }
        public DateTime? createdTime { get; set; }
        public object? category { get; set; }
        public string? language { get; set; }
        public object? subCategory { get; set; }
        public object? priority { get; set; }
        public string? channel { get; set; }
        public DateTime? dueDate { get; set; }
        public DateTime? responseDueDate { get; set; }
        public string? commentCount { get; set; }
        public object? sentiment { get; set; }
        public string? threadCount { get; set; }
        public DateTime? closedTime { get; set; }
        public object? onholdTime { get; set; }
        public object? accountId { get; set; }
        public string? departmentId { get; set; }
        public string? contactId { get; set; }
        public object? productId { get; set; }
        public string? assigneeId { get; set; }
        public object? teamId { get; set; }
        public string? relationshipType { get; set; }
        public bool? isSpam { get; set; }
        public object? channelCode { get; set; }
        public LastThread? lastThread { get; set; }
        public DateTime? customerResponseTime { get; set; }
        public bool? isArchived { get; set; }
        public TicketSource? source { get; set; }
        public string? webUrl { get; set; }
    }

    public class TicketSource
    {
        public object extId { get; set; }
        public object appName { get; set; }
        public object appPhotoURL { get; set; }
        public object permalink { get; set; }
        public string type { get; set; }
    }


}
