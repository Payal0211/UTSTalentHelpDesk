using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenOnBoardTalentsReplacementDetailRepository : GenericRepository<GenOnBoardTalentsReplacementDetail>, IGenOnBoardTalentsReplacementDetailRepository
{
public GenOnBoardTalentsReplacementDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
