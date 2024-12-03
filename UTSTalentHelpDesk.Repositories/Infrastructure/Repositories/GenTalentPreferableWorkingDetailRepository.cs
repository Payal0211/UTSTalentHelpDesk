using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentPreferableWorkingDetailRepository : GenericRepository<GenTalentPreferableWorkingDetail>, IGenTalentPreferableWorkingDetailRepository
{
public GenTalentPreferableWorkingDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
