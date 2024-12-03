using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTempInterestMergePrgTalentInterestRepository : GenericRepository<PrgTempInterestMergePrgTalentInterest>, IPrgTempInterestMergePrgTalentInterestRepository
{
public PrgTempInterestMergePrgTalentInterestRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
