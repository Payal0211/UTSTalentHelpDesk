using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgHistoryActionRepository : GenericRepository<PrgHistoryAction>, IPrgHistoryActionRepository
{
public PrgHistoryActionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
