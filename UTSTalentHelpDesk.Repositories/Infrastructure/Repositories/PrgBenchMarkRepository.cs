using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgBenchMarkRepository : GenericRepository<PrgBenchMark>, IPrgBenchMarkRepository
{
public PrgBenchMarkRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
