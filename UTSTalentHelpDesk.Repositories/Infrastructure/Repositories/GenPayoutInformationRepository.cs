using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenPayoutInformationRepository : GenericRepository<GenPayoutInformation>, IGenPayoutInformationRepository
{
public GenPayoutInformationRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
