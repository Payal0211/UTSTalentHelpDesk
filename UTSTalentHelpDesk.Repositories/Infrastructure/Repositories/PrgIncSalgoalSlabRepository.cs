using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgIncSalgoalSlabRepository : GenericRepository<PrgIncSalgoalSlab>, IPrgIncSalgoalSlabRepository
{
public PrgIncSalgoalSlabRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
