using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentPreferableWorkingRepository : GenericRepository<PrgTalentPreferableWorking>, IPrgTalentPreferableWorkingRepository
{
public PrgTalentPreferableWorkingRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
