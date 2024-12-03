using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenCompanyLegalInfoRepository : GenericRepository<GenCompanyLegalInfo>, IGenCompanyLegalInfoRepository
{
public GenCompanyLegalInfoRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
