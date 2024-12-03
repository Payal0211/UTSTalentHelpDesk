using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class UsrUserRoleDetailRepository : GenericRepository<UsrUserRoleDetail>, IUsrUserRoleDetailRepository
{
public UsrUserRoleDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
