using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface ITicket
    {
        void CreateTicket(string param);
        void UpdateTicket(string param);
        void SaveAllTickets(string param);
        void SaveTickets(string param);
        void SaveZohoTickets(string param);
        void SaveZohoWebHookTickets(string param);
        void SaveZohoWebHookPrevTickets(string param);
        void deleteZohoTickets(string param);
        void saveContacts(string param);           
        Task<long> InsertZohoWebHookLogs(TsGenZohoTicketsWebhookEvent genZohoTicketsWebhookEvent);
        void saveZohoWebHookEvent(string param);
        Task<TS_sproc_GetToken_Result> GetTokenList(string strparams);
        Task<List<TS_Sproc_Get_Zoho_Tickets_BasedOnUser_Result>> GetZohoTicketsBasedOnUser(string param);
        TsGenTalentTicket SaveUpdateTicketHistory(TsGenTalentTicket talentTicket);
    }
}
