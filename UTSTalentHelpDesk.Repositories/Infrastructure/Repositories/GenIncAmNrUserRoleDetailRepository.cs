using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenIncAmNrUserRoleDetailRepository : GenericRepository<GenIncAmNrUserRoleDetail>, IGenIncAmNrUserRoleDetailRepository
{
public GenIncAmNrUserRoleDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
