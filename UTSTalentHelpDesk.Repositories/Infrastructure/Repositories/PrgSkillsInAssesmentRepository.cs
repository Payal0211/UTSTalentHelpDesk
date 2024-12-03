using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgSkillsInAssesmentRepository : GenericRepository<PrgSkillsInAssesment>, IPrgSkillsInAssesmentRepository
{
public PrgSkillsInAssesmentRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
