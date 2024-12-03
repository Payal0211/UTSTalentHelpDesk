using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentClientTeleRepository : GenericRepository<GenTalentClientTele>, IGenTalentClientTeleRepository
{
public GenTalentClientTeleRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
