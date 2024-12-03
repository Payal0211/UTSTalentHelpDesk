using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentAssesmentScoreRepository : GenericRepository<GenTalentAssesmentScore>, IGenTalentAssesmentScoreRepository
{
public GenTalentAssesmentScoreRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
