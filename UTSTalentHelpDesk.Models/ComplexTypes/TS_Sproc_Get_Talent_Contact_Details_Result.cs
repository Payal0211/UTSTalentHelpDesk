using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class TS_Sproc_Get_Talent_Contact_Details_Result
    {
        public string? EmailID { get; set; }
        public string? FullName { get; set; }
        public long? CompanyID { get; set; }
        public long? ID { get; set; }
        public string? TalentName { get; set; }
        public string? TalentEmail { get; set; }
    }
}
