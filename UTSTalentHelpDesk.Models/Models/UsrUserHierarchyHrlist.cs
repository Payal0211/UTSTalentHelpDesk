using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class UsrUserHierarchyHrlist
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public long ParentId { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedByDatetime { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedByDatetime { get; set; }
    }
}
