using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenCompanyWeightedAverageCriterionRepository : GenericRepository<GenCompanyWeightedAverageCriterion>, IGenCompanyWeightedAverageCriterionRepository
{
public GenCompanyWeightedAverageCriterionRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
