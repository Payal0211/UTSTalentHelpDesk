using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgSkillRankRepository : GenericRepository<PrgSkillRank>, IPrgSkillRankRepository
{
public PrgSkillRankRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
