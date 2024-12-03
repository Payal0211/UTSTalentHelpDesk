using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgMatchMakingSubFactorRepository : GenericRepository<PrgMatchMakingSubFactor>, IPrgMatchMakingSubFactorRepository
{
public PrgMatchMakingSubFactorRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
