using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTempInterestRepository : GenericRepository<PrgTempInterest>, IPrgTempInterestRepository
{
public PrgTempInterestRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
