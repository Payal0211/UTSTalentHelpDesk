using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenContactTalentPriorityRepository : GenericRepository<GenContactTalentPriority>, IGenContactTalentPriorityRepository
{
public GenContactTalentPriorityRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
