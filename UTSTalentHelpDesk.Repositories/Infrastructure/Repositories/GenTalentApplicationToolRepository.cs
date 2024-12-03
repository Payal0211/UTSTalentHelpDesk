using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentApplicationToolRepository : GenericRepository<GenTalentApplicationTool>, IGenTalentApplicationToolRepository
{
public GenTalentApplicationToolRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
