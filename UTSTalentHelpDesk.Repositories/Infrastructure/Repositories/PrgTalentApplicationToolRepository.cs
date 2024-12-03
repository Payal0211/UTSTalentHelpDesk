using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentApplicationToolRepository : GenericRepository<PrgTalentApplicationTool>, IPrgTalentApplicationToolRepository
{
public PrgTalentApplicationToolRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
