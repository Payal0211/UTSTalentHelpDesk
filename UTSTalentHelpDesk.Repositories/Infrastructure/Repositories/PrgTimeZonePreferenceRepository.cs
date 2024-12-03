using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTimeZonePreferenceRepository : GenericRepository<PrgTimeZonePreference>, IPrgTimeZonePreferenceRepository
{
public PrgTimeZonePreferenceRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
