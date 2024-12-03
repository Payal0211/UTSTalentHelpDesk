using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgDealStatusRepository : GenericRepository<PrgDealStatus>, IPrgDealStatusRepository
{
public PrgDealStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
