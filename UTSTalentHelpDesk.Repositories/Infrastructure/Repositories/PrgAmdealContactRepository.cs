using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgAmdealContactRepository : GenericRepository<PrgAmdealContact>, IPrgAmdealContactRepository
{
public PrgAmdealContactRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
