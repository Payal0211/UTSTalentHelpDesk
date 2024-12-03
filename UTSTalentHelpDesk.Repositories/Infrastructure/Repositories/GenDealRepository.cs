using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenDealRepository : GenericRepository<GenDeal>, IGenDealRepository
{
public GenDealRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
