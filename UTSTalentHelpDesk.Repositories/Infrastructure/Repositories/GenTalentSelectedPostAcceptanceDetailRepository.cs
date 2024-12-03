using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentSelectedPostAcceptanceDetailRepository : GenericRepository<GenTalentSelectedPostAcceptanceDetail>, IGenTalentSelectedPostAcceptanceDetailRepository
{
public GenTalentSelectedPostAcceptanceDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
