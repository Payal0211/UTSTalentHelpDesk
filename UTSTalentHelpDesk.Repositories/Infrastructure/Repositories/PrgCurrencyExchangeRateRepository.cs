using UTSTalentHelpDesk.Models.Generic;
using UTSTalentHelpDesk.Models.Models;
namespace UTSTalentHelpDesk.Repositories.Infrastructure.Repositories
{
public class PrgCurrencyExchangeRateRepository : GenericRepository<PrgCurrencyExchangeRate>, IPrgCurrencyExchangeRateRepository
{
public PrgCurrencyExchangeRateRepository(UTSTalentHelpDeskDBConnection dbContext) : base(dbContext){}
}
}
