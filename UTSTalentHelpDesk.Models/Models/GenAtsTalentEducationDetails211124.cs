using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenAtsTalentEducationDetails211124
    {
        public long Id { get; set; }
        public long? AtsId { get; set; }
        public long? AtsTalentId { get; set; }
        public long? UtsInstituteCollegeId { get; set; }
        public string? AtsTalentEducation { get; set; }
        public int? ClusterKey { get; set; }
        public string? ClusterName { get; set; }
        public int? GroupClusterKey { get; set; }
        public string? GroupClusterName { get; set; }
        public string? AnotherClusterName { get; set; }
        public string? NewTalentEducation { get; set; }
    }
}
