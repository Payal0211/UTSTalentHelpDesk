using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenUTSTalentHelpDeskRecordRepository : GenericRepository<GenUTSTalentHelpDeskRecord>, IGenUTSTalentHelpDeskRecordRepository
{
public GenUTSTalentHelpDeskRecordRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
