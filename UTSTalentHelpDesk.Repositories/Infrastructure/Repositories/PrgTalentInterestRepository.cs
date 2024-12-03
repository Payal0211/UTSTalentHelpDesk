using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentInterestRepository : GenericRepository<PrgTalentInterest>, IPrgTalentInterestRepository
{
public PrgTalentInterestRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
