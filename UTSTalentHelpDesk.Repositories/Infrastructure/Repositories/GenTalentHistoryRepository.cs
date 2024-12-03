using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentHistoryRepository : GenericRepository<GenTalentHistory>, IGenTalentHistoryRepository
{
public GenTalentHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
