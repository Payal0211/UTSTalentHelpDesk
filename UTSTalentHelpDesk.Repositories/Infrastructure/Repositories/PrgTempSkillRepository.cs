using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTempSkillRepository : GenericRepository<PrgTempSkill>, IPrgTempSkillRepository
{
public PrgTempSkillRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
