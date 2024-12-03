using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class UsrUserHierarchyRepository : GenericRepository<UsrUserHierarchy>, IUsrUserHierarchyRepository
{
public UsrUserHierarchyRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
