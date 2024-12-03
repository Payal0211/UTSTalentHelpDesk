using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgDealStageRepository : GenericRepository<PrgDealStage>, IPrgDealStageRepository
{
public PrgDealStageRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
