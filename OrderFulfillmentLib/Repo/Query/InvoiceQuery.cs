using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OrderFulfillmentLib.Repo.Query
{
    public class InvoiceQuery : IInvoiceQuery
    {
        OrderFulfillmentDbContext context;
        ILogger<InvoiceQuery> logger;

        public InvoiceQuery(OrderFulfillmentDbContext context, ILogger<InvoiceQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public Invoice GetInvoice(int id)
        {
            Invoice invoice = new Invoice();
            try
            {
                var query = context.invoices.Find(id);
                if (query == null)
                {
                    invoice = null;
                }
                else
                {
                    invoice = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return invoice;
        }

        public List<Invoice> SearchInvoice(InvoiceQueryParameter invoiceQueryParameter)
        {
            List<Invoice> invoices = new List<Invoice>();
            try
            {
                var query = context.invoices.AsQueryable();
                query = query.Where(a => a.status == 1);
                if (invoiceQueryParameter.print_status != null)
                {
                    query = query.Where(a => a.print_status == invoiceQueryParameter.print_status);
                }
                if (invoiceQueryParameter.order_id != null)
                {
                    query = query.Where(a => a.order_id == invoiceQueryParameter.order_id);
                }

                if (query.Count() > 0)
                {
                    invoices = query.OrderBy(b => b.id)
                    .Skip((invoiceQueryParameter.PageNumber - 1) * invoiceQueryParameter.PageSize)
                                            .Take(invoiceQueryParameter.PageSize).Select(a => new Invoice
                                            {
                                                dt_crtd = a.dt_crtd,
                                                id = a.id,
                                                order_id = a.order_id,
                                                status = a.status,
                                                dt_modf = a.dt_modf,
                                                image = a.image,
                                                print_date = a.print_date,
                                                print_status = a.print_status


                                            }).ToList();

                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return invoices;
        }
    }
}
