﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSTalentHelpDesk.Models.ComplexTypes;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface ITicket
    {
        void CreateTicket(string param);
        void UpdateTicket(string param);
        void SaveAllTickets(string param);
        void SaveTickets(string param);
        void SaveZohoTickets(string param);
        void deleteZohoTickets(string param);
        void saveContacts(string param);
        Task<TS_sproc_GetToken_Result> GetTokenList(string strparams);
    }
}
