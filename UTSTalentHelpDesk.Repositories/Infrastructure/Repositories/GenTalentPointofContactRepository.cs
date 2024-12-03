using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentPointofContactRepository : GenericRepository<GenTalentPointofContact>, IGenTalentPointofContactRepository
{
public GenTalentPointofContactRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
