using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenNearByLocation
    {
        public long Id { get; set; }
        public long? DistrictId { get; set; }
        public long? MappingDistrictId { get; set; }
    }
}
