using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHiringRequestDetailsHistoryRepository : GenericRepository<GenSalesHiringRequestDetailsHistory>, IGenSalesHiringRequestDetailsHistoryRepository
{
public GenSalesHiringRequestDetailsHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
