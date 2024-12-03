using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHrTracceptedDetailRepository : GenericRepository<GenSalesHrTracceptedDetail>, IGenSalesHrTracceptedDetailRepository
{
public GenSalesHrTracceptedDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
