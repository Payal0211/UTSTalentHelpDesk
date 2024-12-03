using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgInterviewStatusRepository : GenericRepository<PrgInterviewStatus>, IPrgInterviewStatusRepository
{
public PrgInterviewStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
