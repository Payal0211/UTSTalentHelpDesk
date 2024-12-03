using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenAibasedHrtalentMatchMakingRepository : GenericRepository<GenAibasedHrtalentMatchMaking>, IGenAibasedHrtalentMatchMakingRepository
{
public GenAibasedHrtalentMatchMakingRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
