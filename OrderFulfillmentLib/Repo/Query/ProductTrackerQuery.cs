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

namespace OrderFulfillmentLib.Repo.Query
{
    public class ProductTrackerQuery : IProductTrackerQuery
    {
        OrderFulfillmentDbContext context;
        ILogger<ProductTrackerQuery> logger;

        public ProductTrackerQuery(OrderFulfillmentDbContext context, ILogger<ProductTrackerQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public ProductTracker GetProductTracker(int id)
        {
            ProductTracker productTracker = new ProductTracker();
            try
            {
                var query = context.productTrackers.Find(id);
                if (query == null)
                {
                    productTracker = null;
                }
                else
                {
                    productTracker = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return productTracker;
        }

        public List<ProductTracker> SearchProductTracker(ProductTrackerQueryParameter productTrackerQueryParameter)
        {
            List<ProductTracker> productTrackers = new List<ProductTracker>();
            try
            {
                var query = context.productTrackers.AsQueryable();
                query = query.Where(a => a.status == 1);
                if (productTrackerQueryParameter.order_status != null)
                {
                    query = query.Where(a => a.order_status == productTrackerQueryParameter.order_status);
                }
                if (productTrackerQueryParameter.order_id != null)
                {
                    query = query.Where(a => a.order_id == productTrackerQueryParameter.order_id);
                }
                if (productTrackerQueryParameter.order_loc != null)
                {
                    query = query.Where(a => a.order_loc.Contains(productTrackerQueryParameter.order_loc));
                }

                if (productTrackerQueryParameter.dtcreatedfrom != null)
                {
                    query = query.Where(a => a.dt_crtd >= productTrackerQueryParameter.dtcreatedfrom);
                }
                if (productTrackerQueryParameter.dtcreatedto != null)
                {
                    query = query.Where(a => a.dt_crtd <= productTrackerQueryParameter.dtcreatedto);
                }



                if (query.Count() > 0)
                {
                    productTrackers = query.OrderBy(b => b.id)
                    .Skip((productTrackerQueryParameter.PageNumber - 1) * productTrackerQueryParameter.PageSize)
                                            .Take(productTrackerQueryParameter.PageSize).Select(a => new ProductTracker
                                            {
                                                dt_crtd = a.dt_crtd,
                                                id = a.id,
                                                order_id = a.order_id,
                                                comment = a.comment,
                                                order_loc = a.order_loc,
                                                order_status = a.order_status,
                                                uniqueid = a.uniqueid,
                                                status = a.status,
                                                dt_modf = a.dt_modf

                                            }).ToList();

                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return productTrackers;
        }
    }
}
