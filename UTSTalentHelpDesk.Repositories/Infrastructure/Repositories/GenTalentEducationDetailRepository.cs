using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentEducationDetailRepository : GenericRepository<GenTalentEducationDetail>, IGenTalentEducationDetailRepository
{
public GenTalentEducationDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
