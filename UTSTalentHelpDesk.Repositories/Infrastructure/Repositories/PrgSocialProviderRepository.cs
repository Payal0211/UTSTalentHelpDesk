using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgSocialProviderRepository : GenericRepository<PrgSocialProvider>, IPrgSocialProviderRepository
{
public PrgSocialProviderRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
