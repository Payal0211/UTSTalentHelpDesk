using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentTypeRepository : GenericRepository<PrgTalentType>, IPrgTalentTypeRepository
{
public PrgTalentTypeRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
