using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgApitimeZoneResponseRepository : GenericRepository<PrgApitimeZoneResponse>, IPrgApitimeZoneResponseRepository
{
public PrgApitimeZoneResponseRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
