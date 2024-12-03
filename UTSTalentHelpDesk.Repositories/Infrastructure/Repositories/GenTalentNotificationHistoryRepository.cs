using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentNotificationHistoryRepository : GenericRepository<GenTalentNotificationHistory>, IGenTalentNotificationHistoryRepository
{
public GenTalentNotificationHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
