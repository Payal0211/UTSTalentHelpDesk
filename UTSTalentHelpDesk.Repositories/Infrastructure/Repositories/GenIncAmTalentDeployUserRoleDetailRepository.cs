using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenIncAmTalentDeployUserRoleDetailRepository : GenericRepository<GenIncAmTalentDeployUserRoleDetail>, IGenIncAmTalentDeployUserRoleDetailRepository
{
public GenIncAmTalentDeployUserRoleDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
