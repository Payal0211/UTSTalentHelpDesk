using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Repositories.Interfaces
{
    public interface IZohoInvoice
    {
        void WebhookZohoInvoiceUpdateZohoInvoiceUpdateWebhook(string param);
        void ZohoContactUpdateWebhook(string param);
    }
}
