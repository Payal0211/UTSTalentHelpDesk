using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{   
    public class Change
    {
        public string newValue { get; set; }
        public string field { get; set; }
    }

    public class TicketHistory
    {
        public string name { get; set; }
        public DateTime eventTime { get; set; }
        public string webLabel { get; set; }
        public string customerName { get; set; }
        public string recipients { get; set; }
        public string ruleName { get; set; }
        public string notificationType { get; set; }
        public List<Change> changes { get; set; }
        public string agentId { get; set; }
        public string agentName { get; set; }
    }

}
