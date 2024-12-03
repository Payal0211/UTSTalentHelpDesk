using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHrJddumpRepository : GenericRepository<GenSalesHrJddump>, IGenSalesHrJddumpRepository
{
public GenSalesHrJddumpRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
