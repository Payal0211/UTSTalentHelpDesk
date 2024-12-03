using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenAibasedHrtalentMatchMakingDetailRepository : GenericRepository<GenAibasedHrtalentMatchMakingDetail>, IGenAibasedHrtalentMatchMakingDetailRepository
{
public GenAibasedHrtalentMatchMakingDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
