using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenClientHappinessSurveyOptionRepository : GenericRepository<GenClientHappinessSurveyOption>, IGenClientHappinessSurveyOptionRepository
{
public GenClientHappinessSurveyOptionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
