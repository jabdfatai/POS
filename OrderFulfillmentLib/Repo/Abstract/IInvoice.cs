using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Repo.Abstract
{
    public interface IInvoiceCommand
    {
        int AddInvoice(Invoice invoice);
        int PatchInvoice(int id, InvoicePatchViewModel invoicePatchViewModel);
        bool DeleteInvoice(int id);
    }
    public interface IInvoiceQuery
    {
        List<Invoice> SearchInvoice(InvoiceQueryParameter invoiceQueryParameter);
        Invoice GetInvoice(int id);
    }
}
