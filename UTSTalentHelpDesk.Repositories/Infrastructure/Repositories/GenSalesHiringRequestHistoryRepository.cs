using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHiringRequestHistoryRepository : GenericRepository<GenSalesHiringRequestHistory>, IGenSalesHiringRequestHistoryRepository
{
public GenSalesHiringRequestHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
