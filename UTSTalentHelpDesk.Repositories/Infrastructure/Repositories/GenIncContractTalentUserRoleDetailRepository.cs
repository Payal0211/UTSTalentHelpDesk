using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenIncContractTalentUserRoleDetailRepository : GenericRepository<GenIncContractTalentUserRoleDetail>, IGenIncContractTalentUserRoleDetailRepository
{
public GenIncContractTalentUserRoleDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
