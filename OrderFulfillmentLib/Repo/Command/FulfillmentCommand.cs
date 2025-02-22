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
    public class FulfillmentCommand : IFulfillmentCommand
    {
        OrderFulfillmentDbContext context;
        ILogger<FulfillmentCommand> logger;
        int resultid = 0;
        public FulfillmentCommand(OrderFulfillmentDbContext context,
        ILogger<FulfillmentCommand> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public int AddFulfillment(Fulfillment fulfillment)
        {
            try
            {
                context.fulfillments.Add(fulfillment);
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteFulfillment(int id)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.fulfillments.Find(id);
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

        public int PatchFulfillment(int id, FulfillmentPatchViewModel fulfillmentPatchViewModel)
        {
            try
            {
                var selrec = context.fulfillments.Find(id);
                selrec.fulfillment_status = fulfillmentPatchViewModel.fulfillment_status == null ? selrec.fulfillment_status : fulfillmentPatchViewModel.fulfillment_status.Value;
                selrec.paymentid = fulfillmentPatchViewModel.paymentid == null ? selrec.paymentid : fulfillmentPatchViewModel.paymentid.Value; ;
                selrec.remarks = fulfillmentPatchViewModel.remarks == null ? selrec.remarks : fulfillmentPatchViewModel.remarks;
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
