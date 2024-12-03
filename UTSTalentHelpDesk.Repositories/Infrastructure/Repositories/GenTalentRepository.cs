using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentRepository : GenericRepository<GenTalent>, IGenTalentRepository
{
public GenTalentRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
