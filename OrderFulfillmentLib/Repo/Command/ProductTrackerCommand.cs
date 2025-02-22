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
    public class ProductTrackerCommand : IProductTrackerCommand
    {
        OrderFulfillmentDbContext context;
        ILogger<ProductTrackerCommand> logger;
        int resultid = 0;
        public ProductTrackerCommand(OrderFulfillmentDbContext context,
        ILogger<ProductTrackerCommand> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public int AddProductTracker(ProductTracker productTracker)
        {
            try
            {
                context.productTrackers.Add(productTracker);
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteProductTracker(int id)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.productTrackers.Find(id);
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

        public int PatchProductTracker(int id, ProductTrackerPatchViewModel productTrackerPatchViewModel)
        {
            try
            {
                var selrec = context.productTrackers.Find(id);
                selrec.comment = productTrackerPatchViewModel.comment == null ? selrec.comment : productTrackerPatchViewModel.comment;
                selrec.order_status = productTrackerPatchViewModel.order_status == null ? selrec.order_status : productTrackerPatchViewModel.order_status.Value;
                selrec.order_loc = productTrackerPatchViewModel.order_loc == null ? selrec.order_loc : productTrackerPatchViewModel.order_loc;
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
