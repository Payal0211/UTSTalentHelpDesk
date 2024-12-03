using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentLegalInfoRepository : GenericRepository<GenTalentLegalInfo>, IGenTalentLegalInfoRepository
{
public GenTalentLegalInfoRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
