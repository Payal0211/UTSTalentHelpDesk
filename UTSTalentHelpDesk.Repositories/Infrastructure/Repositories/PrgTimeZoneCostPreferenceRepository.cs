using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTimeZoneCostPreferenceRepository : GenericRepository<PrgTimeZoneCostPreference>, IPrgTimeZoneCostPreferenceRepository
{
public PrgTimeZoneCostPreferenceRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
