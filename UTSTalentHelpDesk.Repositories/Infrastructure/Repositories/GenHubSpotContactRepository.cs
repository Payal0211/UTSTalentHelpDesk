using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenHubSpotContactRepository : GenericRepository<GenHubSpotContact>, IGenHubSpotContactRepository
{
public GenHubSpotContactRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
