using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenIncUserTargetsHistoryRepository : GenericRepository<GenIncUserTargetsHistory>, IGenIncUserTargetsHistoryRepository
{
public GenIncUserTargetsHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
