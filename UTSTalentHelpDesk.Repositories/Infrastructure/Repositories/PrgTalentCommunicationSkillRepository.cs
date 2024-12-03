using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentCommunicationSkillRepository : GenericRepository<PrgTalentCommunicationSkill>, IPrgTalentCommunicationSkillRepository
{
public PrgTalentCommunicationSkillRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
