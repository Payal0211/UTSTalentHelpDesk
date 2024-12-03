using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class HubspotWebhookNotificationRepository : GenericRepository<HubspotWebhookNotification>, IHubspotWebhookNotificationRepository
{
public HubspotWebhookNotificationRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
