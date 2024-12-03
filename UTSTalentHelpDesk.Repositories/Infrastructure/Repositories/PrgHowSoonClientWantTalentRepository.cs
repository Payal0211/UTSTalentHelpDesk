using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgHowSoonClientWantTalentRepository : GenericRepository<PrgHowSoonClientWantTalent>, IPrgHowSoonClientWantTalentRepository
{
public PrgHowSoonClientWantTalentRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
