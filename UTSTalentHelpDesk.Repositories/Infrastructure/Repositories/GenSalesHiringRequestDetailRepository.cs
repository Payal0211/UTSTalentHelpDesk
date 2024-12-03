using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHiringRequestDetailRepository : GenericRepository<GenSalesHiringRequestDetail>, IGenSalesHiringRequestDetailRepository
{
public GenSalesHiringRequestDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
