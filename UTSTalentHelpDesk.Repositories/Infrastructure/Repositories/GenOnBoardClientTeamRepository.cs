using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenOnBoardClientTeamRepository : GenericRepository<GenOnBoardClientTeam>, IGenOnBoardClientTeamRepository
{
public GenOnBoardClientTeamRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
