using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgRolesAndResponsilbityRepository : GenericRepository<PrgRolesAndResponsilbity>, IPrgRolesAndResponsilbityRepository
{
public PrgRolesAndResponsilbityRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
