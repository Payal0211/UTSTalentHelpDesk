using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenShortlistedTalentInterviewDetailRepository : GenericRepository<GenShortlistedTalentInterviewDetail>, IGenShortlistedTalentInterviewDetailRepository
{
public GenShortlistedTalentInterviewDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
