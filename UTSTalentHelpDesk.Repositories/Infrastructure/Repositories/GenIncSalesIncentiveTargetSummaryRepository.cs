using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenIncSalesIncentiveTargetSummaryRepository : GenericRepository<GenIncSalesIncentiveTargetSummary>, IGenIncSalesIncentiveTargetSummaryRepository
{
public GenIncSalesIncentiveTargetSummaryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
