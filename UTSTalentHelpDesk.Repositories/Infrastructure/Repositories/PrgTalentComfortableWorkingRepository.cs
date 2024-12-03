using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentComfortableWorkingRepository : GenericRepository<PrgTalentComfortableWorking>, IPrgTalentComfortableWorkingRepository
{
public PrgTalentComfortableWorkingRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
