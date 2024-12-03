using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentComfortableAreaRepository : GenericRepository<PrgTalentComfortableArea>, IPrgTalentComfortableAreaRepository
{
public PrgTalentComfortableAreaRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
