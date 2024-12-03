using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenUserHistoryRepository : GenericRepository<GenUserHistory>, IGenUserHistoryRepository
{
public GenUserHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
