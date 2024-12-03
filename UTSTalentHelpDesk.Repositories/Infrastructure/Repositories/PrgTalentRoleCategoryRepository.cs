using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentRoleCategoryRepository : GenericRepository<PrgTalentRoleCategory>, IPrgTalentRoleCategoryRepository
{
public PrgTalentRoleCategoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
