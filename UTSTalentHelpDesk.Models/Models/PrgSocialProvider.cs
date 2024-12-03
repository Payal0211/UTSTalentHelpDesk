using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class PrgSocialProvider
    {
        public int Id { get; set; }
        public string SocialProviderName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
