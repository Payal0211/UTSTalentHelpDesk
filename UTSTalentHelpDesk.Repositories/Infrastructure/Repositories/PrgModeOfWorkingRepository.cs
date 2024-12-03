using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgModeOfWorkingRepository : GenericRepository<PrgModeOfWorking>, IPrgModeOfWorkingRepository
{
public PrgModeOfWorkingRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
