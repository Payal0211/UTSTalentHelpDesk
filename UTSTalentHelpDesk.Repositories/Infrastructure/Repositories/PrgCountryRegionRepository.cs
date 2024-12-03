using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgCountryRegionRepository : GenericRepository<PrgCountryRegion>, IPrgCountryRegionRepository
{
public PrgCountryRegionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
