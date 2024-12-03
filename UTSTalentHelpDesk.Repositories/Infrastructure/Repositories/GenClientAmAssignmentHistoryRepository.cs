using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenClientAmAssignmentHistoryRepository : GenericRepository<GenClientAmAssignmentHistory>, IGenClientAmAssignmentHistoryRepository
{
public GenClientAmAssignmentHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
