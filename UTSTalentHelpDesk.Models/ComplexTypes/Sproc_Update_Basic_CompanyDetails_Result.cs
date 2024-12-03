using Microsoft.EntityFrameworkCore;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    [Keyless]
    public class Sproc_Update_Basic_CompanyDetails_Result
    {
        public long? CompanyID { get; set; }
        public string? CompanyNumber { get; set; }
    }
}
