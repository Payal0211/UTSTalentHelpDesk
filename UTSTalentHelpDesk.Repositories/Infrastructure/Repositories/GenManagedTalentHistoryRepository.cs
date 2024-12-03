using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenManagedTalentHistoryRepository : GenericRepository<GenManagedTalentHistory>, IGenManagedTalentHistoryRepository
{
public GenManagedTalentHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
