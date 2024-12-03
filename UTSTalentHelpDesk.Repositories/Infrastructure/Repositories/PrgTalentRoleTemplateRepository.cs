using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentRoleTemplateRepository : GenericRepository<PrgTalentRoleTemplate>, IPrgTalentRoleTemplateRepository
{
public PrgTalentRoleTemplateRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
