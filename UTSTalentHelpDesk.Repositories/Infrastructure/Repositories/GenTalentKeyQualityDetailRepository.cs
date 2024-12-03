using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentKeyQualityDetailRepository : GenericRepository<GenTalentKeyQualityDetail>, IGenTalentKeyQualityDetailRepository
{
public GenTalentKeyQualityDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
