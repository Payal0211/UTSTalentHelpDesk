using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenOnBoardTalentsClientFeedbackRepository : GenericRepository<GenOnBoardTalentsClientFeedback>, IGenOnBoardTalentsClientFeedbackRepository
{
public GenOnBoardTalentsClientFeedbackRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
