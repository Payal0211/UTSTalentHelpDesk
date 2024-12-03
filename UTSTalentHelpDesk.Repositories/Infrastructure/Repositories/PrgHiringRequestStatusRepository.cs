using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgHiringRequestStatusRepository : GenericRepository<PrgHiringRequestStatus>, IPrgHiringRequestStatusRepository
{
public PrgHiringRequestStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
