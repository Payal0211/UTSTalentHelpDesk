using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentSelectionHistoryRepository : GenericRepository<GenTalentSelectionHistory>, IGenTalentSelectionHistoryRepository
{
public GenTalentSelectionHistoryRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
