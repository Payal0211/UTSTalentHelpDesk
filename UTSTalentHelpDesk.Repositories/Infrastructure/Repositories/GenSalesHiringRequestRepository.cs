using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHiringRequestRepository : GenericRepository<GenSalesHiringRequest>, IGenSalesHiringRequestRepository
{
public GenSalesHiringRequestRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
