using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentComfortableAreaDetailRepository : GenericRepository<GenTalentComfortableAreaDetail>, IGenTalentComfortableAreaDetailRepository
{
public GenTalentComfortableAreaDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
