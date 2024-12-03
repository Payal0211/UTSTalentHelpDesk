using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenUtsOnBoardLineItemRepository : GenericRepository<GenUtsOnBoardLineItem>, IGenUtsOnBoardLineItemRepository
{
public GenUtsOnBoardLineItemRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
