using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenIncUserTargetRepository : GenericRepository<GenIncUserTarget>, IGenIncUserTargetRepository
{
public GenIncUserTargetRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
