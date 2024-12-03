using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenContactPendingActionRepository : GenericRepository<GenContactPendingAction>, IGenContactPendingActionRepository
{
public GenContactPendingActionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
