using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgClientHappinessSurveyFeedbackOptionRepository : GenericRepository<PrgClientHappinessSurveyFeedbackOption>, IPrgClientHappinessSurveyFeedbackOptionRepository
{
public PrgClientHappinessSurveyFeedbackOptionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
