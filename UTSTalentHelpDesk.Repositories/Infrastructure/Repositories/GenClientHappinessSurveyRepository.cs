using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenClientHappinessSurveyRepository : GenericRepository<GenClientHappinessSurvey>, IGenClientHappinessSurveyRepository
{
public GenClientHappinessSurveyRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
