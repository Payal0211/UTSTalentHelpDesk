using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenAmnbdAssignmentEmailsendDetailRepository : GenericRepository<GenAmnbdAssignmentEmailsendDetail>, IGenAmnbdAssignmentEmailsendDetailRepository
{
public GenAmnbdAssignmentEmailsendDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
