using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgDealPipelineRepository : GenericRepository<PrgDealPipeline>, IPrgDealPipelineRepository
{
public PrgDealPipelineRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
