using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenClientCalendarEventRepository : GenericRepository<GenClientCalendarEvent>, IGenClientCalendarEventRepository
{
public GenClientCalendarEventRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
