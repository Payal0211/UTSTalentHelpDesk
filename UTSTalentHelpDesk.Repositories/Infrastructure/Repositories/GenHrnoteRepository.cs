using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenHrnoteRepository : GenericRepository<GenHrnote>, IGenHrnoteRepository
{
public GenHrnoteRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
