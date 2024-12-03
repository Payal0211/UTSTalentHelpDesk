using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class UsrUserTypeAndRoleDetailRepository : GenericRepository<UsrUserTypeAndRoleDetail>, IUsrUserTypeAndRoleDetailRepository
{
public UsrUserTypeAndRoleDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
