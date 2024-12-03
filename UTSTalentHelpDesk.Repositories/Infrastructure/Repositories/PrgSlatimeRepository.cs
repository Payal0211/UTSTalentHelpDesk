using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgSlatimeRepository : GenericRepository<PrgSlatime>, IPrgSlatimeRepository
{
public PrgSlatimeRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
