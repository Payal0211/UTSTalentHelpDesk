using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentInterviewFeedbackRepository : GenericRepository<GenTalentInterviewFeedback>, IGenTalentInterviewFeedbackRepository
{
public GenTalentInterviewFeedbackRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
