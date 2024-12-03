using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgGeoRepository : GenericRepository<PrgGeo>, IPrgGeoRepository
{
public PrgGeoRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
