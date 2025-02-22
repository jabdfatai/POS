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
    public class PaymentCommand : IPaymentCommand
    {
        OrderFulfillmentDbContext context;
        ILogger<PaymentCommand> logger;
        int resultid = 0;
        public PaymentCommand(OrderFulfillmentDbContext context, ILogger<PaymentCommand> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public int AddPayment(Payment payment)
        {
            try
            {
                context.payments.Add(payment);
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeletePayment(int id)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.payments.Find(id);
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

        public int PatchPayment(int id, PaymentPatchViewModel paymentPatchViewModel)
        {
            try
            {
                var selrec = context.payments.Find(id);
                selrec.payment_status = paymentPatchViewModel.payment_status == null ? selrec.payment_status : paymentPatchViewModel.payment_status.Value;
                selrec.payment_date = paymentPatchViewModel.payment_date == null ? selrec.payment_date : paymentPatchViewModel.payment_date.Value;
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
