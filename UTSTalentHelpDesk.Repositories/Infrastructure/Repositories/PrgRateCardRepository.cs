using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgRateCardRepository : GenericRepository<PrgRateCard>, IPrgRateCardRepository
{
public PrgRateCardRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
