using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenDirectPlacementRepository : GenericRepository<GenDirectPlacement>, IGenDirectPlacementRepository
{
public GenDirectPlacementRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
