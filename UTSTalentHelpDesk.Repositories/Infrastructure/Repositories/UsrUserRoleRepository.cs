using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class UsrUserRoleRepository : GenericRepository<UsrUserRole>, IUsrUserRoleRepository
{
public UsrUserRoleRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
