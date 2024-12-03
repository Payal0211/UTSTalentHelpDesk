using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenMenuMasterRepository : GenericRepository<GenMenuMaster>, IGenMenuMasterRepository
{
public GenMenuMasterRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
