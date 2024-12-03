using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgSummaryStagesForReportRepository : GenericRepository<PrgSummaryStagesForReport>, IPrgSummaryStagesForReportRepository
{
public PrgSummaryStagesForReportRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
