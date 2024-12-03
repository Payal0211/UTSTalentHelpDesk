using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentTimeZoneRepository : GenericRepository<PrgTalentTimeZone>, IPrgTalentTimeZoneRepository
{
public PrgTalentTimeZoneRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
