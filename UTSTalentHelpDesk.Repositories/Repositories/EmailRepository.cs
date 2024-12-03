using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Helpers;
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
      
    }
}
