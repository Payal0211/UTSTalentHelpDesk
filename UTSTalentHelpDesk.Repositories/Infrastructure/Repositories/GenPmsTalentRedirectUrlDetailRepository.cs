using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenPmsTalentRedirectUrlDetailRepository : GenericRepository<GenPmsTalentRedirectUrlDetail>, IGenPmsTalentRedirectUrlDetailRepository
{
public GenPmsTalentRedirectUrlDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
