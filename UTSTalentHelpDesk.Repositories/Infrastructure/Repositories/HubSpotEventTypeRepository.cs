using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class HubSpotEventTypeRepository : GenericRepository<HubSpotEventType>, IHubSpotEventTypeRepository
{
public HubSpotEventTypeRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
