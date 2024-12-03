using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgCompanyTargetGroupRepository : GenericRepository<PrgCompanyTargetGroup>, IPrgCompanyTargetGroupRepository
{
public PrgCompanyTargetGroupRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
