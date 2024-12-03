using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenEsalesAmApiResponseRepository : GenericRepository<GenEsalesAmApiResponse>, IGenEsalesAmApiResponseRepository
{
public GenEsalesAmApiResponseRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
