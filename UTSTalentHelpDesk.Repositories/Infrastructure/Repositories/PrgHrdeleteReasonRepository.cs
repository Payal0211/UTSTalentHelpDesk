using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgHrdeleteReasonRepository : GenericRepository<PrgHrdeleteReason>, IPrgHrdeleteReasonRepository
{
public PrgHrdeleteReasonRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
