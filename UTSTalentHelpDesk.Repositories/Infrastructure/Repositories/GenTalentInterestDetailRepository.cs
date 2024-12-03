using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentInterestDetailRepository : GenericRepository<GenTalentInterestDetail>, IGenTalentInterestDetailRepository
{
public GenTalentInterestDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
