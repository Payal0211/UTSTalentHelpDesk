using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenCompanyLeadTypeUserDetailRepository : GenericRepository<GenCompanyLeadTypeUserDetail>, IGenCompanyLeadTypeUserDetailRepository
{
public GenCompanyLeadTypeUserDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
