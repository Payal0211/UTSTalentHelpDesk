using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgIncPlacementFeesSlabRepository : GenericRepository<PrgIncPlacementFeesSlab>, IPrgIncPlacementFeesSlabRepository
{
public PrgIncPlacementFeesSlabRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
