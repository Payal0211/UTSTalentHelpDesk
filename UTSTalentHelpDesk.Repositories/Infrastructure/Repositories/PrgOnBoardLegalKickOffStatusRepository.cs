using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgOnBoardLegalKickOffStatusRepository : GenericRepository<PrgOnBoardLegalKickOffStatus>, IPrgOnBoardLegalKickOffStatusRepository
{
public PrgOnBoardLegalKickOffStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
