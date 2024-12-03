using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
    public class PrgTalentSecondarySkillRepository : GenericRepository<PrgTalentSecondarySkill>, IPrgTalentSecondarySkillRepository
    {
        public PrgTalentSecondarySkillRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext) { }
    }
}
