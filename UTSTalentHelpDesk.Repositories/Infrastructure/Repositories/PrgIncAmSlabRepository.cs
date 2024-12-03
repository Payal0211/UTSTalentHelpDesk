using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgIncAmSlabRepository : GenericRepository<PrgIncAmSlab>, IPrgIncAmSlabRepository
{
public PrgIncAmSlabRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
