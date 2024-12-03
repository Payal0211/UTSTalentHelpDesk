using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgOrgLevelRepository : GenericRepository<PrgOrgLevel>, IPrgOrgLevelRepository
{
public PrgOrgLevelRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
