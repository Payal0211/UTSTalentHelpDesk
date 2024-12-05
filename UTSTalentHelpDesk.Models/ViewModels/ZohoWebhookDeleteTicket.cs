using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class ZohoWebhookDeleteTicket
    {
        public Payload Payload { get; set; }
        public string EventTime { get; set; }
        public string EventType { get; set; }
        public string OrgId { get; set; }   
    }
    public class Payload
    {
        public string Id { get; set; }
    }
}
