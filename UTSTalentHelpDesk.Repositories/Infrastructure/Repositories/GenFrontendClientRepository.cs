using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenFrontendClientRepository : GenericRepository<GenFrontendClient>, IGenFrontendClientRepository
{
public GenFrontendClientRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
