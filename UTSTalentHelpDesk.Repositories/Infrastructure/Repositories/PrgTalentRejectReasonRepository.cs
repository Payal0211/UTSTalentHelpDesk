using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentRejectReasonRepository : GenericRepository<PrgTalentRejectReason>, IPrgTalentRejectReasonRepository
{
public PrgTalentRejectReasonRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
