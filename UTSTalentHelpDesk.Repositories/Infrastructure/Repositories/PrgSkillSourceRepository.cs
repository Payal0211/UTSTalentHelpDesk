using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgSkillSourceRepository : GenericRepository<PrgSkillSource>, IPrgSkillSourceRepository
{
public PrgSkillSourceRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
