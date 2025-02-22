using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.Server;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Repo.Command
{
    public class InvoiceCommand : IInvoiceCommand
    {
        OrderFulfillmentDbContext context;
        ILogger<InvoiceCommand> logger;
        int resultid = 0;

        public InvoiceCommand(OrderFulfillmentDbContext context, ILogger<InvoiceCommand> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public int AddInvoice(Invoice invoice)
        {
            try
            {
                context.invoices.Add(invoice);
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteInvoice(int id)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.invoices.Find(id);
                selrec.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int PatchInvoice(int id, InvoicePatchViewModel invoicePatchViewModel)
        {
            try
            {
                var selrec = context.invoices.Find(id);
                selrec.print_date = invoicePatchViewModel.print_date == null ? selrec.print_date : invoicePatchViewModel.print_date.Value;
                selrec.print_status = invoicePatchViewModel.print_status == null ? selrec.print_status : invoicePatchViewModel.print_status.Value;
                selrec.image = invoicePatchViewModel.image == null ? selrec.image : invoicePatchViewModel.image;
                selrec.dt_modf = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }
    }
}
