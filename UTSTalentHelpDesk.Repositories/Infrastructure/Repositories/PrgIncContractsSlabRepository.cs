using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgIncContractsSlabRepository : GenericRepository<PrgIncContractsSlab>, IPrgIncContractsSlabRepository
{
public PrgIncContractsSlabRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
