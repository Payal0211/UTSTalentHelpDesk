using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentStatusRepository : GenericRepository<PrgTalentStatus>, IPrgTalentStatusRepository
{
public PrgTalentStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
