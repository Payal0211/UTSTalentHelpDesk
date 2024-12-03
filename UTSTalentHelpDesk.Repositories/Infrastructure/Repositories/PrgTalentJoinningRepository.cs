using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentJoinningRepository : GenericRepository<PrgTalentJoinning>, IPrgTalentJoinningRepository
{
public PrgTalentJoinningRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
