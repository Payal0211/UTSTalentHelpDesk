using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class TicketResponse
    {
        public List<Ticket> Data { get; set; }
    }
    public class Source
    {
        public string AppName { get; set; }
        public string ExtId { get; set; }
        public string Type { get; set; }
        public string Permalink { get; set; }
        public string AppPhotoURL { get; set; }
    }

    public class Account
    {
        public string Website { get; set; }
        public string AccountName { get; set; }
        public string Id { get; set; }
    }

    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }
    }

    public class Assignee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoURL { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
    }

    public class Ticket
    {
        public string TicketNumber { get; set; }
        public string SubCategory { get; set; }
        public string Subject { get; set; }
        public DateTime? DueDate { get; set; }
        public string DepartmentId { get; set; }
        public string Channel { get; set; }
        public DateTime? OnholdTime { get; set; }
        public Source Source { get; set; }
        public DateTime? ClosedTime { get; set; }
        public string SharedCount { get; set; }
        public DateTime? ResponseDueDate { get; set; }
        public Contact Contact { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string ChannelCode { get; set; }
        public DateTime? CustomerResponseTime { get; set; }
        public string ProductId { get; set; }
        public string ContactId { get; set; }
        public string ThreadCount { get; set; }
        public string Priority { get; set; }
        public string AssigneeId { get; set; }
        public string CommentCount { get; set; }
        public string AccountId { get; set; }
        public string Phone { get; set; }
        public string WebUrl { get; set; }
        public bool IsSpam { get; set; }
        public Assignee Assignee { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }
}
