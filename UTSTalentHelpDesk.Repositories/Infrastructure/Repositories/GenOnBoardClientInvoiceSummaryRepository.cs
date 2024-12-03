using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenOnBoardClientInvoiceSummaryRepository : GenericRepository<GenOnBoardClientInvoiceSummary>, IGenOnBoardClientInvoiceSummaryRepository
{
public GenOnBoardClientInvoiceSummaryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
