using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgStateSubDistrict
    {
        public long Id { get; set; }
        public long? DistrictId { get; set; }
        public string? SubDistrict { get; set; }
    }
}
