using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentPayOutAdditionalLineItemRepository : GenericRepository<GenTalentPayOutAdditionalLineItem>, IGenTalentPayOutAdditionalLineItemRepository
{
public GenTalentPayOutAdditionalLineItemRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
