using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentTestimonialOrFeedbackRepository : GenericRepository<GenTalentTestimonialOrFeedback>, IGenTalentTestimonialOrFeedbackRepository
{
public GenTalentTestimonialOrFeedbackRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
