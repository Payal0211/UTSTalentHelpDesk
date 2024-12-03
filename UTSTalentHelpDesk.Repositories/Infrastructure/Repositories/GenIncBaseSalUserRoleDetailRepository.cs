using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenIncBaseSalUserRoleDetailRepository : GenericRepository<GenIncBaseSalUserRoleDetail>, IGenIncBaseSalUserRoleDetailRepository
{
public GenIncBaseSalUserRoleDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
