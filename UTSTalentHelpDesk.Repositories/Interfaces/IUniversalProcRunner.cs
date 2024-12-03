using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface IUniversalProcRunner
    {
        public object Manipulation(string proName, object[] args);
        public object ManipulationWithNULL(string proName, object[] args);
        public void InsertReactPayload(GenUtsadminReactPayload genUtsadminReactPayload);
    }
}
