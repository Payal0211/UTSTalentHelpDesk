using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTicketTechnicalJustificationRepository : GenericRepository<PrgTicketTechnicalJustification>, IPrgTicketTechnicalJustificationRepository
{
public PrgTicketTechnicalJustificationRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
