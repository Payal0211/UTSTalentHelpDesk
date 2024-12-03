using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgPreOnBoardStatusRepository : GenericRepository<PrgPreOnBoardStatus>, IPrgPreOnBoardStatusRepository
{
public PrgPreOnBoardStatusRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
