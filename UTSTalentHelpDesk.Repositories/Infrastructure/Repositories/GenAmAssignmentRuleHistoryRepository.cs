using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenAmAssignmentRuleHistoryRepository : GenericRepository<GenAmAssignmentRuleHistory>, IGenAmAssignmentRuleHistoryRepository
{
public GenAmAssignmentRuleHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
