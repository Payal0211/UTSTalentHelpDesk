using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgClientEngagementModelRepository : GenericRepository<PrgClientEngagementModel>, IPrgClientEngagementModelRepository
{
public PrgClientEngagementModelRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
