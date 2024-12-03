using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentPayoutStatusRepository : GenericRepository<PrgTalentPayoutStatus>, IPrgTalentPayoutStatusRepository
{
public PrgTalentPayoutStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
