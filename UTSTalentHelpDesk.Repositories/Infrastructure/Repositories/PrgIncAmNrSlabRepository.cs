using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgIncAmNrSlabRepository : GenericRepository<PrgIncAmNrSlab>, IPrgIncAmNrSlabRepository
{
public PrgIncAmNrSlabRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
