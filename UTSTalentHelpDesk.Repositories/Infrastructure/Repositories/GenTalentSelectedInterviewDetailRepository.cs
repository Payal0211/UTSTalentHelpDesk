using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentSelectedInterviewDetailRepository : GenericRepository<GenTalentSelectedInterviewDetail>, IGenTalentSelectedInterviewDetailRepository
{
public GenTalentSelectedInterviewDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
