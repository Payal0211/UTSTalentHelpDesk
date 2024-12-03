using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTicketStatusRepository : GenericRepository<PrgTicketStatus>, IPrgTicketStatusRepository
{
public PrgTicketStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
