using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgExtractedSkillsforJdparsingRepository : GenericRepository<PrgExtractedSkillsforJdparsing>, IPrgExtractedSkillsforJdparsingRepository
{
public PrgExtractedSkillsforJdparsingRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
