using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgCompanyDomainRepository : GenericRepository<PrgCompanyDomain>, IPrgCompanyDomainRepository
{
public PrgCompanyDomainRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
