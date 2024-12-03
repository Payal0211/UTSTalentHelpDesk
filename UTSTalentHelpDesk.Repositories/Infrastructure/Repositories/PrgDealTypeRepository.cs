using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgDealTypeRepository : GenericRepository<PrgDealType>, IPrgDealTypeRepository
{
public PrgDealTypeRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
