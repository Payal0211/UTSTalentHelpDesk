using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenDealTicketRepository : GenericRepository<GenDealTicket>, IGenDealTicketRepository
{
public GenDealTicketRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
