using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class StoreAPIUrlRepository : GenericRepository<StoreApiurl>, IStoreAPIUrlRepository
{
public StoreAPIUrlRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
