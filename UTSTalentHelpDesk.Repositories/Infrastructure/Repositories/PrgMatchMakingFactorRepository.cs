using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgMatchMakingFactorRepository : GenericRepository<PrgMatchMakingFactor>, IPrgMatchMakingFactorRepository
{
public PrgMatchMakingFactorRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
