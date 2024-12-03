using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class UsrUserTypeRepository : GenericRepository<UsrUserType>, IUsrUserTypeRepository
{
public UsrUserTypeRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
