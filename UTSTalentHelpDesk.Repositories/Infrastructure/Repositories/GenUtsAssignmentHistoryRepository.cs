using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenUtsAssignmentHistoryRepository : GenericRepository<GenUtsAssignmentHistory>, IGenUtsAssignmentHistoryRepository
{
public GenUtsAssignmentHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
