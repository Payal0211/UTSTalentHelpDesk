using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenCompanyRepository : GenericRepository<GenCompany>, IGenCompanyRepository
{
public GenCompanyRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
