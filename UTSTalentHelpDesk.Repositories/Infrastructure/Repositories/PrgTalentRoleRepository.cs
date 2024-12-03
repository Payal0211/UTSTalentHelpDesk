using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentRoleRepository : GenericRepository<PrgTalentRole>, IPrgTalentRoleRepository
{
public PrgTalentRoleRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
