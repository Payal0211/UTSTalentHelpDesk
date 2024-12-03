using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenChannelBookmarkMessage
    {
        public long Id { get; set; }
        public long ChannelId { get; set; }
        public long MessageId { get; set; }
        public long CreatedById { get; set; }
    }
}
