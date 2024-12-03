using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTempSkillsMergePrgSkillRepository : GenericRepository<PrgTempSkillsMergePrgSkill>, IPrgTempSkillsMergePrgSkillRepository
{
public PrgTempSkillsMergePrgSkillRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
