using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class UsrUserGeoDetailRepository : GenericRepository<UsrUserGeoDetail>, IUsrUserGeoDetailRepository
{
public UsrUserGeoDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
