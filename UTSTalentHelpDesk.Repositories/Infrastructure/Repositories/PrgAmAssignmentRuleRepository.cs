using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgAmAssignmentRuleRepository : GenericRepository<PrgAmAssignmentRule>, IPrgAmAssignmentRuleRepository
{
public PrgAmAssignmentRuleRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
