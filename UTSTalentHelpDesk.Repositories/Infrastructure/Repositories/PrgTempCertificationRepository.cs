using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTempCertificationRepository : GenericRepository<PrgTempCertification>, IPrgTempCertificationRepository
{
public PrgTempCertificationRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
