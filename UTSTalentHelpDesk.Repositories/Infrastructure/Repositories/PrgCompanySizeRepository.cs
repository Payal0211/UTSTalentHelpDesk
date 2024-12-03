using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgCompanySizeRepository : GenericRepository<PrgCompanySize>, IPrgCompanySizeRepository
{
public PrgCompanySizeRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
