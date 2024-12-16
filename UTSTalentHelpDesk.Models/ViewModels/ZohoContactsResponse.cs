using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class ZohoContactsResponse
    {
        public List<Contacts> Data { get; set; }
    }

    public class Contacts
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountCount { get; set; }
        public string Email { get; set; }
        public string SecondaryEmail { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedTime { get; set; }
        public string OwnerId { get; set; }
        public string AccountId { get; set; }
        public bool IsSpam { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsEndUser { get; set; }
        public string webUrl { get; set; }
    }
}
