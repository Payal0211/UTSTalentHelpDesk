using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHiringRequestPriorityRepository : GenericRepository<GenSalesHiringRequestPriority>, IGenSalesHiringRequestPriorityRepository
{
public GenSalesHiringRequestPriorityRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
