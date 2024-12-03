using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHiringRequestInterviewerDetailRepository : GenericRepository<GenSalesHiringRequestInterviewerDetail>, IGenSalesHiringRequestInterviewerDetailRepository
{
public GenSalesHiringRequestInterviewerDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
