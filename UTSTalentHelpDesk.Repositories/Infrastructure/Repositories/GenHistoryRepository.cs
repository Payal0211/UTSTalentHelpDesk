using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenHistoryRepository : GenericRepository<GenHistory>, IGenHistoryRepository
{
public GenHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
