using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenCompanyContractDetailRepository : GenericRepository<GenCompanyContractDetail>, IGenCompanyContractDetailRepository
{
public GenCompanyContractDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
