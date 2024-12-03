using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentAssesmentSkillScoreRepository : GenericRepository<GenTalentAssesmentSkillScore>, IGenTalentAssesmentSkillScoreRepository
{
public GenTalentAssesmentSkillScoreRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
