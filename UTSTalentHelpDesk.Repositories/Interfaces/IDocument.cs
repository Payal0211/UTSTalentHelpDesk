using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.ComplexTypes;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface IDocument
    {
        void CreateDocument(string param);
        void VerifyDocument(string param);
        Task<List<TS_Sproc_Get_Talent_DocumentList_Result>> Get_Talent_DocumentList(string param);
    }
}
