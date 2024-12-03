using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class UsrUserPriorityCountLogRepository : GenericRepository<UsrUserPriorityCountLog>, IUsrUserPriorityCountLogRepository
{
public UsrUserPriorityCountLogRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
