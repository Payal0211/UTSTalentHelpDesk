using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentKeyQualityRepository : GenericRepository<PrgTalentKeyQuality>, IPrgTalentKeyQualityRepository
{
public PrgTalentKeyQualityRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
