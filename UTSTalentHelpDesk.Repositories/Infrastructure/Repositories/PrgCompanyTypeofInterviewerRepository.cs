using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgCompanyTypeofInterviewerRepository : GenericRepository<PrgCompanyTypeofInterviewer>, IPrgCompanyTypeofInterviewerRepository
{
public PrgCompanyTypeofInterviewerRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
