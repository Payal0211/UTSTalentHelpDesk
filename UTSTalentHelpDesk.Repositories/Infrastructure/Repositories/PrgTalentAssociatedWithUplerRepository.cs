using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentAssociatedWithUplerRepository : GenericRepository<PrgTalentAssociatedWithUpler>, IPrgTalentAssociatedWithUplerRepository
{
public PrgTalentAssociatedWithUplerRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
