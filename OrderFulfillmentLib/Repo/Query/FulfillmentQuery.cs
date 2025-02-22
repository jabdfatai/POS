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
    public class FulfillmentQuery : IFulfillmentQuery
    {
        OrderFulfillmentDbContext context;
        ILogger<FulfillmentQuery> logger;
        public FulfillmentQuery(OrderFulfillmentDbContext context, ILogger<FulfillmentQuery> logger)
        {
            this.context = context;

            this.logger = logger;

        }
        public Fulfillment GetFulfillment(int id)
        {
            Fulfillment fulfillment = new Fulfillment();
            try
            {
                var query = context.fulfillments.Find(id);
                if (query == null)
                {
                    fulfillment = null;
                }
                else
                {
                    fulfillment = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return fulfillment;
        }

        public List<Fulfillment> SearchFulfillment(FulfillmentQueryParameter fulfillmentQueryParameter)
        {
            List<Fulfillment> fulfillments = new List<Fulfillment>();
            try
            {
                var query = context.fulfillments.AsQueryable();
                query = query.Where(a => a.status == 1);
                if (fulfillmentQueryParameter.paymentid != null)
                {
                    query = query.Where(a => a.paymentid == fulfillmentQueryParameter.paymentid);
                }
                if (fulfillmentQueryParameter.order_id != null)
                {
                    query = query.Where(a => a.order_id == fulfillmentQueryParameter.order_id);
                }
                if (fulfillmentQueryParameter.fulfillment_status != null)
                {
                    query = query.Where(a => a.fulfillment_status == fulfillmentQueryParameter.fulfillment_status);
                }
                if (fulfillmentQueryParameter.dtcreatedfrom != null)
                {
                    query = query.Where(a => a.dt_crtd >= fulfillmentQueryParameter.dtcreatedfrom);
                }
                if (fulfillmentQueryParameter.dtcreatedto != null)
                {
                    query = query.Where(a => a.dt_crtd <= fulfillmentQueryParameter.dtcreatedto);
                }

                if (query.Count() > 0)
                {
                    fulfillments = query.OrderBy(b => b.id)
                    .Skip((fulfillmentQueryParameter.PageNumber - 1) * fulfillmentQueryParameter.PageSize)
                                            .Take(fulfillmentQueryParameter.PageSize).Select(a => new Fulfillment
                                            {
                                                dt_crtd = a.dt_crtd,
                                                
                                                id = a.id,
                                                fulfillment_status = a.fulfillment_status,
                                                order_id = a.order_id,
                                                paymentid = a.paymentid,
                                                remarks = a.remarks,
                                                status = a.status,
                                                dt_modf = a.dt_modf

                                            }).ToList();

                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return fulfillments;

        }
    }
}
