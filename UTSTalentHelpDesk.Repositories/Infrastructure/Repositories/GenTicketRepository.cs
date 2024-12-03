using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTicketRepository : GenericRepository<GenTicket>, IGenTicketRepository
{
public GenTicketRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
