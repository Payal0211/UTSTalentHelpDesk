using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentSelectedInterviewerDetailRepository : GenericRepository<GenTalentSelectedInterviewerDetail>, IGenTalentSelectedInterviewerDetailRepository
{
public GenTalentSelectedInterviewerDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
