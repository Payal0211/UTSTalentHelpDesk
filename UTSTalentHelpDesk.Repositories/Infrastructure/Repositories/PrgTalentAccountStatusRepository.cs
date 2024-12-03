using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentAccountStatusRepository : GenericRepository<PrgTalentAccountStatus>, IPrgTalentAccountStatusRepository
{
public PrgTalentAccountStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
