using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenCompanyUpdateRepository : GenericRepository<GenCompanyUpdate>, IGenCompanyUpdateRepository
{
public GenCompanyUpdateRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
