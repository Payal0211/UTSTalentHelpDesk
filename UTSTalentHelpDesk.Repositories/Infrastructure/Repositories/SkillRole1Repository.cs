using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class SkillRole1Repository : GenericRepository<SkillRole1>, ISkillRole1Repository
{
public SkillRole1Repository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
