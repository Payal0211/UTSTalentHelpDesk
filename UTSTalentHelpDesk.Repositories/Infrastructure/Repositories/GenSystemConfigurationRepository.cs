using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSystemConfigurationRepository : GenericRepository<GenSystemConfiguration>, IGenSystemConfigurationRepository
{
public GenSystemConfigurationRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
