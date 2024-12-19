using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenAtsTalentEducationDetailsMismatchcluster
    {
        public long Id { get; set; }
        public long? AtsId { get; set; }
        public long? AtsTalentId { get; set; }
        public string? AtsTalentEducation { get; set; }
        public string? NewTalentEducation { get; set; }
        public string? ClusterName { get; set; }
        public int? SimilarityScore { get; set; }
    }
}
