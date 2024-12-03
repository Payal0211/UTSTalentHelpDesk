using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTestimonialRepository : GenericRepository<GenTestimonial>, IGenTestimonialRepository
{
public GenTestimonialRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
