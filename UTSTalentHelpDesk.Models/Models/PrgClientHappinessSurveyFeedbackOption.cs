﻿using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgClientHappinessSurveyFeedbackOption
    {
        public int Id { get; set; }
        public string? HappynessSurvayOption { get; set; }
        public int? QuestionId { get; set; }
        public bool? IsActive { get; set; }
    }
}
