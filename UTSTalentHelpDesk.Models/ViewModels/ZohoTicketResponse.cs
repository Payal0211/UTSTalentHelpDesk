using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class ZohoTicketResponse
    {
        [JsonProperty("ticketId")]
        public string TicketId { get; set; }

        [JsonProperty("ticketNumber")]
        public string TicketNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("createdTime")]
        public DateTime CreatedTime { get; set; }
    }
}
