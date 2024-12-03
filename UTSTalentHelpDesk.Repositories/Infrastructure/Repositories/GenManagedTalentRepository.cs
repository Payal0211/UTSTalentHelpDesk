using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenManagedTalentRepository : GenericRepository<GenManagedTalent>, IGenManagedTalentRepository
{
public GenManagedTalentRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
