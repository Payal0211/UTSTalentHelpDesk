using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenOnBoardClientDevicePolicyDetailRepository : GenericRepository<GenOnBoardClientDevicePolicyDetail>, IGenOnBoardClientDevicePolicyDetailRepository
{
public GenOnBoardClientDevicePolicyDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
