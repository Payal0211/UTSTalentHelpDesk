using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenClientHappinessSurveyQuestionRepository : GenericRepository<GenClientHappinessSurveyQuestion>, IGenClientHappinessSurveyQuestionRepository
{
public GenClientHappinessSurveyQuestionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
