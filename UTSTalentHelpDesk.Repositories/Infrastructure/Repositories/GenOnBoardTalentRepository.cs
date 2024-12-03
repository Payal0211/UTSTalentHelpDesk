using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenOnBoardTalentRepository : GenericRepository<GenOnBoardTalent>, IGenOnBoardTalentRepository
{
public GenOnBoardTalentRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
