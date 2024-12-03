using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenContactInterviewFeedbackRepository : GenericRepository<GenContactInterviewFeedback>, IGenContactInterviewFeedbackRepository
{
public GenContactInterviewFeedbackRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
