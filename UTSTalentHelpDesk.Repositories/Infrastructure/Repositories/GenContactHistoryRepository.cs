using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenContactHistoryRepository : GenericRepository<GenContactHistory>, IGenContactHistoryRepository
{
public GenContactHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
