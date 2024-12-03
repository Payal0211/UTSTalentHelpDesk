using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenClientHappinessSurveyOption
    {
        public long Id { get; set; }
        public long? HappynessSurvayFeedbackId { get; set; }
        public int? HappynessSurvayOptionId { get; set; }
    }
}
