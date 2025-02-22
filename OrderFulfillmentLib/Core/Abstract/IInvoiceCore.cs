
using Common.Model;
using Common.Response;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;

namespace OrderFulfillmentLib.Core.Abstract
{
    public interface IInvoiceCore
    {
        public CommandResponse AddInvoice(InvoiceAddViewModel InvoiceAddViewModel);

        public CommandResponse UpdateInvoice(int Invoiceid, InvoicePatchViewModel InvoicePatchViewModel);
        public CommandResponse PatchInvoice(int Invoiceid, InvoicePatchViewModel InvoicePatchViewModel);
        public CommandResponse DeleteInvoice(int Invoiceid);

        public QueryResponse<CountModel<Invoice>> GetInvoices(InvoiceQueryParameter InvoiceQueryParameters);

        public QueryResponse<Invoice> GetInvoice(int Invoiceid);
    }



}
