using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgSkillsRoleRepository : GenericRepository<PrgSkillsRole>, IPrgSkillsRoleRepository
{
public PrgSkillsRoleRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
