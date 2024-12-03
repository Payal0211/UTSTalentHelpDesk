using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenHrnotesTagUserDetailRepository : GenericRepository<GenHrnotesTagUserDetail>, IGenHrnotesTagUserDetailRepository
{
public GenHrnotesTagUserDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
