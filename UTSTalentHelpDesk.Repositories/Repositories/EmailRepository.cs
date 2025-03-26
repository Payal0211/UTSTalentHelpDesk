using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Helpers;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Repositories.Interfaces;

namespace UTSTalentHelpDesk.Repositories.Repositories
{
    public class EmailRepository : IEmail
    {
        #region Variables

        private UTSTalentHelpDeskDBConnection _db;  

        #endregion

        #region Constructors
        public EmailRepository(UTSTalentHelpDeskDBConnection db, IUnitOfWork unitOfWork)
        {
            _db = db; 
        }
        #endregion

        #region public API
        public TS_Sproc_Get_Talent_Contact_Details_Result GetTalentContactDetails(long talentID)
        {
            return _db.Set<TS_Sproc_Get_Talent_Contact_Details_Result>().FromSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.TS_Sproc_Get_Talent_Contact_Details, talentID.ToString())).AsEnumerable().FirstOrDefault();
        }

        public string GetPasswordByKey(string key)
        {
            object[] param = new object[] { key };

            string paramasString = CommonLogic.ConvertToParamString(param);

            sp_UTS_get_PasswordData_Result? data = _db.Set<sp_UTS_get_PasswordData_Result>().FromSqlRaw(string.Format("{0} {1}", Constants.ProcConstant.sp_UTS_get_PasswordData, paramasString)).AsEnumerable().FirstOrDefault();

            if (data != null)
            {
                return data.Value ?? "";
            }
            return "";
        }

        #endregion


    }
}
