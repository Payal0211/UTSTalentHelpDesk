using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgRequirementRepository : GenericRepository<PrgRequirement>, IPrgRequirementRepository
{
public PrgRequirementRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
