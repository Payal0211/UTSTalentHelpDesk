using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgClientLegalDocumentTypeRepository : GenericRepository<PrgClientLegalDocumentType>, IPrgClientLegalDocumentTypeRepository
{
public PrgClientLegalDocumentTypeRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
