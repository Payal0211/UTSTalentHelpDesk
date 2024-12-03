using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenOnBoardClientLeavePolicyRepository : GenericRepository<GenOnBoardClientLeavePolicy>, IGenOnBoardClientLeavePolicyRepository
{
public GenOnBoardClientLeavePolicyRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
