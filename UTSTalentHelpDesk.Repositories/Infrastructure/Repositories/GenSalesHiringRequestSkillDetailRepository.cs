using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSalesHiringRequestSkillDetailRepository : GenericRepository<GenSalesHiringRequestSkillDetail>, IGenSalesHiringRequestSkillDetailRepository
{
public GenSalesHiringRequestSkillDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
