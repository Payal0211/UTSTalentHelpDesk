using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenContactNotificationHistoryRepository : GenericRepository<GenContactNotificationHistory>, IGenContactNotificationHistoryRepository
{
public GenContactNotificationHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
