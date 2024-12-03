using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgCompanyCurrentOpenPositionRepository : GenericRepository<PrgCompanyCurrentOpenPosition>, IPrgCompanyCurrentOpenPositionRepository
{
public PrgCompanyCurrentOpenPositionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
