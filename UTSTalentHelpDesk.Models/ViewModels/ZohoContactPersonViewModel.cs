using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class ZohoContactPersonViewModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<ContactPerson> contact_persons { get; set; }
    }

    public class ContactPerson
    {
        public string contact_person_id { get; set; }
        public string salutation { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string department { get; set; }
        public string designation { get; set; }
        public string skype { get; set; }
        public string fax { get; set; }
        public bool is_primary_contact { get; set; }
        public bool is_added_in_portal { get; set; }
        public bool can_invite { get; set; }
        public bool is_portal_invitation_accepted { get; set; }
        public string photo_url { get; set; }
    }

}
