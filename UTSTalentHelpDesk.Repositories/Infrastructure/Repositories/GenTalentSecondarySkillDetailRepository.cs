using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentSecondarySkillDetailRepository : GenericRepository<GenTalentSecondarySkillDetail>, IGenTalentSecondarySkillDetailRepository
{
public GenTalentSecondarySkillDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
