using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenContactGetHelpQuestionRepository : GenericRepository<GenContactGetHelpQuestion>, IGenContactGetHelpQuestionRepository
{
public GenContactGetHelpQuestionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
