using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentProjectDetailRepository : GenericRepository<GenTalentProjectDetail>, IGenTalentProjectDetailRepository
{
public GenTalentProjectDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
