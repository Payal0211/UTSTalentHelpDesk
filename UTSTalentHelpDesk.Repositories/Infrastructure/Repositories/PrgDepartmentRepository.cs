using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgDepartmentRepository : GenericRepository<PrgDepartment>, IPrgDepartmentRepository
{
public PrgDepartmentRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
