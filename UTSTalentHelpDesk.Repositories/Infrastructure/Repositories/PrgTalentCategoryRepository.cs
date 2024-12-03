using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentCategoryRepository : GenericRepository<PrgTalentCategory>, IPrgTalentCategoryRepository
{
public PrgTalentCategoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
