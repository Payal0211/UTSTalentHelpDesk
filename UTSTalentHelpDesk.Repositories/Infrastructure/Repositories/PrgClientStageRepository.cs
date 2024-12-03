using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgClientStageRepository : GenericRepository<PrgClientStage>, IPrgClientStageRepository
{
public PrgClientStageRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
