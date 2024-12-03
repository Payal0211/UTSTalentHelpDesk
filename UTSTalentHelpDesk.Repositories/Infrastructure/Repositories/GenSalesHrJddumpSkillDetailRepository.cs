using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHrJddumpSkillDetailRepository : GenericRepository<GenSalesHrJddumpSkillDetail>, IGenSalesHrJddumpSkillDetailRepository
{
public GenSalesHrJddumpSkillDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
