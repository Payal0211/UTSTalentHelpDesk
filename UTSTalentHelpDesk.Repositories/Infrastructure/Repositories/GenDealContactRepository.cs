using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenDealContactRepository : GenericRepository<GenDealContact>, IGenDealContactRepository
{
public GenDealContactRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
