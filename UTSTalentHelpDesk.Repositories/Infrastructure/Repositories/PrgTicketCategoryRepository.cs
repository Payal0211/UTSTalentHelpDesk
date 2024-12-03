using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTicketCategoryRepository : GenericRepository<PrgTicketCategory>, IPrgTicketCategoryRepository
{
public PrgTicketCategoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
