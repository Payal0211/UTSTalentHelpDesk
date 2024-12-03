using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentResumeDetailRepository : GenericRepository<GenTalentResumeDetail>, IGenTalentResumeDetailRepository
{
public GenTalentResumeDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
