using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgTalentLegalDocumentTypeRepository : GenericRepository<PrgTalentLegalDocumentType>, IPrgTalentLegalDocumentTypeRepository
{
public PrgTalentLegalDocumentTypeRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
