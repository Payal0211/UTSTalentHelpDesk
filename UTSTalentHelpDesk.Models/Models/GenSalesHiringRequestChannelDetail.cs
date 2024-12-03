using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenSalesHiringRequestChannelDetail
    {
        public long Id { get; set; }
        public long ChannelId { get; set; }
        public long? UserId { get; set; }
    }
}
