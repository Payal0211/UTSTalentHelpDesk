using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentSkillBenchMarkRepository : GenericRepository<PrgTalentSkillBenchMark>, IPrgTalentSkillBenchMarkRepository
{
public PrgTalentSkillBenchMarkRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
