using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenShortlistedTalentRepository : GenericRepository<GenShortlistedTalent>, IGenShortlistedTalentRepository
{
public GenShortlistedTalentRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
