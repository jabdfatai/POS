
using Common.Model;
using Common.Response;
using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Core.Abstract;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Core
{
    public class InvoiceCore : IInvoiceCore
    {
        IInvoiceCommand InvoiceCommand;
        IInvoiceQuery InvoiceQuery;
        ILogger<InvoiceCore> logger;
        public InvoiceCore(IInvoiceCommand InvoiceCommand, IInvoiceQuery InvoiceQuery, ILogger<InvoiceCore> logger)
        {
            this.InvoiceQuery = InvoiceQuery;
            this.logger = logger;
            this.InvoiceCommand = InvoiceCommand;

        }
        public CommandResponse AddInvoice(InvoiceAddViewModel InvoiceAddViewModel)
        {
            int result = 0;
            try
            {
                result = InvoiceCommand.AddInvoice(new Invoice
                {
                    print_date = InvoiceAddViewModel.print_date,
                    image = InvoiceAddViewModel.image,
                    print_status = InvoiceAddViewModel.print_status,
                    order_id = InvoiceAddViewModel.order_id
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddInvoice)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse DeleteInvoice(int Invoiceid)
        {
            bool result = false;
            try
            {
                result = InvoiceCommand.DeleteInvoice(Invoiceid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteInvoice)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Invoice> GetInvoice(int Invoiceid)
        {
            QueryResponse<Invoice> queryResponse = new QueryResponse<Invoice>();
            try
            {
                Invoice Invoice = new Invoice();
                if (Invoiceid != null)
                {
                    Invoice = InvoiceQuery.GetInvoice(Invoiceid);
                    queryResponse = QueryResponse<Invoice>.Load(Invoice);
                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetInvoice)}");
            }


            return queryResponse;
        }

        public QueryResponse<CountModel<Invoice>> GetInvoices(InvoiceQueryParameter InvoiceQueryParameters)
        {
            QueryResponse<CountModel<Invoice>> queryResponse = new QueryResponse<CountModel<Invoice>>();
            try
            {

                var list = InvoiceQuery.SearchInvoice(InvoiceQueryParameters);
                var plist = PagedList<Invoice>.ToPagedIList(list, InvoiceQueryParameters.PageNumber, InvoiceQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Invoice>>.Load(CountModel<Invoice>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetInvoices)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchInvoice(int Invoiceid, InvoicePatchViewModel InvoicePatchViewModel)
        {
            int result = 0;
            try
            {
                result = InvoiceCommand.PatchInvoice(Invoiceid, InvoicePatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchInvoice)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse UpdateInvoice(int Invoiceid, InvoicePatchViewModel InvoicePatchViewModel)
        {
            int result = 0;
            try
            {
                result = InvoiceCommand.PatchInvoice(Invoiceid, InvoicePatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchInvoice)}");
            }
            return CommandResponse.Load(result);
        }
    }
}
