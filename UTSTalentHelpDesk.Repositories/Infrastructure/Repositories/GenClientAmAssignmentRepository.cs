using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenClientAmAssignmentRepository : GenericRepository<GenClientAmAssignment>, IGenClientAmAssignmentRepository
{
public GenClientAmAssignmentRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
