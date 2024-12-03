using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenOnBoardTalentsLegalDetailRepository : GenericRepository<GenOnBoardTalentsLegalDetail>, IGenOnBoardTalentsLegalDetailRepository
{
public GenOnBoardTalentsLegalDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
