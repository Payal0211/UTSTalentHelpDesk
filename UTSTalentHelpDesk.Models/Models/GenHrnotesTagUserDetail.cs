using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenHrnotesTagUserDetail
    {
        public long Id { get; set; }
        public long? NoteId { get; set; }
        public int? AssignedUserId { get; set; }
    }
}
