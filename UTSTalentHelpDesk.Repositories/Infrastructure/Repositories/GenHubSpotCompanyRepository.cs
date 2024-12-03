using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenHubSpotCompanyRepository : GenericRepository<GenHubSpotCompany>, IGenHubSpotCompanyRepository
{
public GenHubSpotCompanyRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
