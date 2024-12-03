using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenIncContractUserRoleDetailRepository : GenericRepository<GenIncContractUserRoleDetail>, IGenIncContractUserRoleDetailRepository
{
public GenIncContractUserRoleDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
