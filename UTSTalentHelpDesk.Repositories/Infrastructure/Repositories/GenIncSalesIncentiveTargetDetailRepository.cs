using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenIncSalesIncentiveTargetDetailRepository : GenericRepository<GenIncSalesIncentiveTargetDetail>, IGenIncSalesIncentiveTargetDetailRepository
{
public GenIncSalesIncentiveTargetDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
