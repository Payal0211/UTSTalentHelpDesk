using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgCrmApiDetailRepository : GenericRepository<PrgCrmApiDetail>, IPrgCrmApiDetailRepository
{
public PrgCrmApiDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
