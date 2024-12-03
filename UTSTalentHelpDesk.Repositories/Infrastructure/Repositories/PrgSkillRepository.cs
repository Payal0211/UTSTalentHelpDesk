using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgSkillRepository : GenericRepository<PrgSkill>, IPrgSkillRepository
{
public PrgSkillRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
