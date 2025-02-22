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
    public class OrderDeliveryQuery : IOrderDeliveryQuery
    {
        OrderFulfillmentDbContext context;
        ILogger<OrderDeliveryQuery> logger;
        public OrderDeliveryQuery(OrderFulfillmentDbContext context,ILogger<OrderDeliveryQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public OrderDelivery GetOrderDelivery(int id)
        {
            OrderDelivery orderDelivery = new OrderDelivery();
            try
            {
                var query = context.orderDeliveries.Find(id);
                if (query == null)
                {
                    orderDelivery = null;
                }
                else
                {
                    orderDelivery = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return orderDelivery;
        }

        public List<OrderDelivery> SearchOrderDelivery(OrderDeliveryQueryParameter orderDeliveryQueryParameter)
        {
            List<OrderDelivery> orderDeliveries = new List<OrderDelivery>();
            try
            {
                var query = context.orderDeliveries.AsQueryable();
                query = query.Where(a => a.status == 1);
                if (orderDeliveryQueryParameter.city != null)
                {
                    query = query.Where(a => a.city == orderDeliveryQueryParameter.city);
                }
                if (orderDeliveryQueryParameter.country != null)
                {
                    query = query.Where(a => a.country == orderDeliveryQueryParameter.country);
                }
                if (orderDeliveryQueryParameter.del_status != null)
                {
                    query = query.Where(a => a.del_status == orderDeliveryQueryParameter.del_status);
                }
                if (orderDeliveryQueryParameter.address != null)
                {
                    query = query.Where(a => (a.add_line1 + " " +  a.add_line2).Contains(orderDeliveryQueryParameter.address));
                }
                if (orderDeliveryQueryParameter.contact_email != null)
                {
                    query = query.Where(a => a.contact_email == orderDeliveryQueryParameter.contact_email);
                }
                if (orderDeliveryQueryParameter.contact_name != null)
                {
                    query = query.Where(a => a.contact_name.Contains(orderDeliveryQueryParameter.contact_name));
                }
                if (orderDeliveryQueryParameter.dtcreatedfrom != null)
                {
                    query = query.Where(a => a.dt_crtd >= orderDeliveryQueryParameter.dtcreatedfrom);
                }
                if (orderDeliveryQueryParameter.dtcreatedto != null)
                {
                    query = query.Where(a => a.dt_crtd <= orderDeliveryQueryParameter.dtcreatedto);
                }

                if (query.Count() > 0)
                {
                    orderDeliveries = query.OrderBy(b => b.id)
                    .Skip((orderDeliveryQueryParameter.PageNumber - 1) * orderDeliveryQueryParameter.PageSize)
                                            .Take(orderDeliveryQueryParameter.PageSize).Select(a => new OrderDelivery
                                            {
                                                dt_crtd = a.dt_crtd,
                                                id = a.id,                                             
                                                order_id = a.order_id,
                                                add_line1 = a.add_line1,
                                                add_line2 = a.add_line2,    
                                                city = a.city,
                                                contact_email = a.contact_email,    
                                                contact_name = a.contact_name,
                                                contact_phone = a.contact_phone,
                                                country = a.country,
                                                del_status = a.del_status,
                                                state = a.state,
                                                zipcode = a.zipcode,                                              
                                                status = a.status,
                                                dt_modf = a.dt_modf

                                            }).ToList();

                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return orderDeliveries;

        }
    }
}
