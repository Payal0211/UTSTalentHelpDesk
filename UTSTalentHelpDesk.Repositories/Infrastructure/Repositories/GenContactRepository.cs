using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenContactRepository : GenericRepository<GenContact>, IGenContactRepository
{
public GenContactRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
