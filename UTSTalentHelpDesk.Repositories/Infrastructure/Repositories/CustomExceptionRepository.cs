using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class CustomExceptionRepository : GenericRepository<CustomException>, ICustomExceptionRepository
{
public CustomExceptionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
