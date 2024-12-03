using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgHiringRequestRoleStatusRepository : GenericRepository<PrgHiringRequestRoleStatus>, IPrgHiringRequestRoleStatusRepository
{
public PrgHiringRequestRoleStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
