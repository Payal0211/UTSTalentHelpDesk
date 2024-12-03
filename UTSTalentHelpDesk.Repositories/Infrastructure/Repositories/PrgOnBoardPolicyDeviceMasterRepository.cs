using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgOnBoardPolicyDeviceMasterRepository : GenericRepository<PrgOnBoardPolicyDeviceMaster>, IPrgOnBoardPolicyDeviceMasterRepository
{
public PrgOnBoardPolicyDeviceMasterRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
