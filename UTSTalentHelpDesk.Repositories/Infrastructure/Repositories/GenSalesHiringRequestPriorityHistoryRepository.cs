using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHiringRequestPriorityHistoryRepository : GenericRepository<GenSalesHiringRequestPriorityHistory>, IGenSalesHiringRequestPriorityHistoryRepository
{
public GenSalesHiringRequestPriorityHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
