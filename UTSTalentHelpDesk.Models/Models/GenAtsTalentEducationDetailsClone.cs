using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenAtsTalentEducationDetailsClone
    {
        public long Id { get; set; }
        public long? AtsId { get; set; }
        public long? UtsInstituteCollegeId { get; set; }
        public string AtsTalentEducation { get; set; } = null!;
        public string? Location { get; set; }
        public int? ClusterKey { get; set; }
        public string? ClusterName { get; set; }
        public int? GroupClusterKey { get; set; }
        public decimal? ClusterRank { get; set; }
        public string? AnotherClusterName { get; set; }
        public int? AnotherClusterId { get; set; }
        public string? AnotherClusterNameXray { get; set; }
    }
}
