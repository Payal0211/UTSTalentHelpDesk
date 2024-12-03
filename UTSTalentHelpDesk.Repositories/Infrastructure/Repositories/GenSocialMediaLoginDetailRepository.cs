using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenSocialMediaLoginDetailRepository : GenericRepository<GenSocialMediaLoginDetail>, IGenSocialMediaLoginDetailRepository
{
public GenSocialMediaLoginDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
