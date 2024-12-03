using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentCertificationRepository : GenericRepository<PrgTalentCertification>, IPrgTalentCertificationRepository
{
public PrgTalentCertificationRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
