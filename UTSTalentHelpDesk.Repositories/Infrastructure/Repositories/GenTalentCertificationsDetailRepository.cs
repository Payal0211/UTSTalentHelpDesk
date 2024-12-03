using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentCertificationsDetailRepository : GenericRepository<GenTalentCertificationsDetail>, IGenTalentCertificationsDetailRepository
{
public GenTalentCertificationsDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
