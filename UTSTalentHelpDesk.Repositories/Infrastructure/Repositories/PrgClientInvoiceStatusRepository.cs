using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgClientInvoiceStatusRepository : GenericRepository<PrgClientInvoiceStatus>, IPrgClientInvoiceStatusRepository
{
public PrgClientInvoiceStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
