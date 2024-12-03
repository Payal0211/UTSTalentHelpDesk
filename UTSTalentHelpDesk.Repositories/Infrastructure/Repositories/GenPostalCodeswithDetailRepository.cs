using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenPostalCodeswithDetailRepository : GenericRepository<GenPostalCodeswithDetail>, IGenPostalCodeswithDetailRepository
{
public GenPostalCodeswithDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
