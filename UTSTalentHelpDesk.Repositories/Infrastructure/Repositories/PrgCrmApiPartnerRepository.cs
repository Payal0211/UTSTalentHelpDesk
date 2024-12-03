using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgCrmApiPartnerRepository : GenericRepository<PrgCrmApiPartner>, IPrgCrmApiPartnerRepository
{
public PrgCrmApiPartnerRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
