using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenIncTargetAcheivedDetailRepository : GenericRepository<GenIncTargetAcheivedDetail>, IGenIncTargetAcheivedDetailRepository
{
public GenIncTargetAcheivedDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
