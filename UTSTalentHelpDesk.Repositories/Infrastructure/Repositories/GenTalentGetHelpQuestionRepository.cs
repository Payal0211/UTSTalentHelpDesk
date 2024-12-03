using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentGetHelpQuestionRepository : GenericRepository<GenTalentGetHelpQuestion>, IGenTalentGetHelpQuestionRepository
{
public GenTalentGetHelpQuestionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
