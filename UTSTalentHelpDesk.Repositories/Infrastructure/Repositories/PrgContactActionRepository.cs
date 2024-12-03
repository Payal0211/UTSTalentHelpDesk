using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgContactActionRepository : GenericRepository<PrgContactAction>, IPrgContactActionRepository
{
public PrgContactActionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
