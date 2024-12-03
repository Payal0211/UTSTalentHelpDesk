using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenInterviewSlotsMasterRepository : GenericRepository<GenInterviewSlotsMaster>, IGenInterviewSlotsMasterRepository
{
public GenInterviewSlotsMasterRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
