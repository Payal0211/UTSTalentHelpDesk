using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentPendingActionRepository : GenericRepository<GenTalentPendingAction>, IGenTalentPendingActionRepository
{
public GenTalentPendingActionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
