using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentActionRepository : GenericRepository<PrgTalentAction>, IPrgTalentActionRepository
{
public PrgTalentActionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
