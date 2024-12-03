using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenContactPointofContactRepository : GenericRepository<GenContactPointofContact>, IGenContactPointofContactRepository
{
public GenContactPointofContactRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
