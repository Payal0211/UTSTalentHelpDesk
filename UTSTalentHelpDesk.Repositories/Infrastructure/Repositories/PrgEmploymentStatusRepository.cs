using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgEmploymentStatusRepository : GenericRepository<PrgEmploymentStatus>, IPrgEmploymentStatusRepository
{
public PrgEmploymentStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
