using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class GenOnBoardClientContractDetailRepository : GenericRepository<GenOnBoardClientContractDetail>, IGenOnBoardClientContractDetailRepository
{
public GenOnBoardClientContractDetailRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
