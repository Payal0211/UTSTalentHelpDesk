using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgPipelineRepository : GenericRepository<PrgPipeline>, IPrgPipelineRepository
{
public PrgPipelineRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
