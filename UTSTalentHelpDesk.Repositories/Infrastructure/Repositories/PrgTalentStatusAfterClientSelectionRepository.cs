using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentStatusAfterClientSelectionRepository : GenericRepository<PrgTalentStatusAfterClientSelection>, IPrgTalentStatusAfterClientSelectionRepository
{
public PrgTalentStatusAfterClientSelectionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
