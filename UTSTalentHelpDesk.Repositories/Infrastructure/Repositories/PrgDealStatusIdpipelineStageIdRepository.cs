using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgDealStatusIdpipelineStageIdRepository : GenericRepository<PrgDealStatusIdpipelineStageId>, IPrgDealStatusIdpipelineStageIdRepository
{
public PrgDealStatusIdpipelineStageIdRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
