using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTimeZoneRepository : GenericRepository<PrgTimeZone>, IPrgTimeZoneRepository
{
public PrgTimeZoneRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
