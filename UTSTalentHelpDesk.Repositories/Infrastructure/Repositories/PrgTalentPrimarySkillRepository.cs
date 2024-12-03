using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentPrimarySkillRepository : GenericRepository<PrgTalentPrimarySkill>, IPrgTalentPrimarySkillRepository
{
public PrgTalentPrimarySkillRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
