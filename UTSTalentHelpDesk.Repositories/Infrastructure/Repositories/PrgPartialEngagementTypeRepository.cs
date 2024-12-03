using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgPartialEngagementTypeRepository : GenericRepository<PrgPartialEngagementType>, IPrgPartialEngagementTypeRepository
{
public PrgPartialEngagementTypeRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
