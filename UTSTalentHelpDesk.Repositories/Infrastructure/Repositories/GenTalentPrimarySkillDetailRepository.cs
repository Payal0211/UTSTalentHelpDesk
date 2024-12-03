using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentPrimarySkillDetailRepository : GenericRepository<GenTalentPrimarySkillDetail>, IGenTalentPrimarySkillDetailRepository
{
public GenTalentPrimarySkillDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
