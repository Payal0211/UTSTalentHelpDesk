using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenTalentFinancialDetailRepository : GenericRepository<GenTalentFinancialDetail>, IGenTalentFinancialDetailRepository
{
public GenTalentFinancialDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
