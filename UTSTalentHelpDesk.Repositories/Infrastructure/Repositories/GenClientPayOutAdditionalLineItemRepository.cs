using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenClientPayOutAdditionalLineItemRepository : GenericRepository<GenClientPayOutAdditionalLineItem>, IGenClientPayOutAdditionalLineItemRepository
{
public GenClientPayOutAdditionalLineItemRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
