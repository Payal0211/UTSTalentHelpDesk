using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTeamRepository : GenericRepository<GenTeam>, IGenTeamRepository
{
public GenTeamRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
