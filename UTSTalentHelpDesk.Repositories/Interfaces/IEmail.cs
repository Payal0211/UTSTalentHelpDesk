using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface IEmail
    {
        TS_Sproc_Get_Talent_Contact_Details_Result GetTalentContactDetails(long talentID);
    }
}
