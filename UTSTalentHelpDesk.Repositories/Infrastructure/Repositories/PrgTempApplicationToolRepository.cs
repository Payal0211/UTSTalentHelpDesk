using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTempApplicationToolRepository : GenericRepository<PrgTempApplicationTool>, IPrgTempApplicationToolRepository
{
public PrgTempApplicationToolRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
