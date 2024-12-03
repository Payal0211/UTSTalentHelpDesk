using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentComfortableWorkingDetailRepository : GenericRepository<GenTalentComfortableWorkingDetail>, IGenTalentComfortableWorkingDetailRepository
{
public GenTalentComfortableWorkingDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
