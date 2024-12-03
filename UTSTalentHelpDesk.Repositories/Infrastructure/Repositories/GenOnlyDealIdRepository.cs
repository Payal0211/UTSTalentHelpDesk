using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenOnlyDealIdRepository : GenericRepository<GenOnlyDealId>, IGenOnlyDealIdRepository
{
public GenOnlyDealIdRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
