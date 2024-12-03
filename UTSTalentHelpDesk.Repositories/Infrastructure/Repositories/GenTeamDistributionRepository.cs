using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTeamDistributionRepository : GenericRepository<GenTeamDistribution>, IGenTeamDistributionRepository
{
public GenTeamDistributionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
