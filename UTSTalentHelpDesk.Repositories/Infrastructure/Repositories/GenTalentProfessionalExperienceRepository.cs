using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentProfessionalExperienceRepository : GenericRepository<GenTalentProfessionalExperience>, IGenTalentProfessionalExperienceRepository
{
public GenTalentProfessionalExperienceRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
