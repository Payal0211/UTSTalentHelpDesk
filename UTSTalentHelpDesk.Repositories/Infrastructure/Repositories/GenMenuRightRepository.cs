using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenMenuRightRepository : GenericRepository<GenMenuRight>, IGenMenuRightRepository
{
public GenMenuRightRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
