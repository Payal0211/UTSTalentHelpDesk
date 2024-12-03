using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgContactTimeZoneRepository : GenericRepository<PrgContactTimeZone>, IPrgContactTimeZoneRepository
{
public PrgContactTimeZoneRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
