using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgContactStatusRepository : GenericRepository<PrgContactStatus>, IPrgContactStatusRepository
{
public PrgContactStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
