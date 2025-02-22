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
    public class OrderQuery : IOrderQuery
    {
        OrderFulfillmentDbContext context;
        ILogger<ProductTrackerQuery> logger;
        public OrderQuery(OrderFulfillmentDbContext context,
        ILogger<ProductTrackerQuery> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Order GetOrder(int id)
        {
            Order order = new Order();
            try
            {
                var query = context.orders.Find(id);
                if (query == null)
                {
                    order = null;
                }
                else
                {
                    order = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return order;
        }

        public OrderDetail GetOrderDetail(int id)
        {
            OrderDetail orderdetail = new OrderDetail();
            try
            {
                var query = context.orderDetails.Find(id);
                if (query == null)
                {
                    orderdetail = null;
                }
                else
                {
                    orderdetail = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return orderdetail;
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int orderid)
        {
            List<OrderDetail> orderdetaillist = new List<OrderDetail>();
            try
            {
                var query = context.orderDetails.Where(a => a.order_id == orderid & a.status == 1);
                if (query == null)
                {
                    orderdetaillist = null;
                }
                else
                {
                    orderdetaillist = query.ToList();
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return orderdetaillist;
        }

        public List<Order> SearchOrder(OrderQueryParameter orderQueryParameter)
        {
            List<Order> orders = new List<Order>();
            try
            {
                var query = context.orders.AsQueryable();
                query = query.Where(a => a.status == 1);
                if (orderQueryParameter.cust_id != null)
                {
                    query = query.Where(a => a.cust_id == orderQueryParameter.cust_id);
                }
                if (orderQueryParameter.del_meth_id != null)
                {
                    query = query.Where(a => a.del_meth_id == orderQueryParameter.del_meth_id);
                }

                if (orderQueryParameter.min_total_amt != null)
                {
                    query = query.Where(a => a.total_amt >= orderQueryParameter.min_total_amt);
                }
                if (orderQueryParameter.max_total_amt != null)
                {
                    query = query.Where(a => a.total_amt <= orderQueryParameter.max_total_amt);
                }
                if (orderQueryParameter.minqty != null)
                {
                    query = query.Where(a => a.qty >= orderQueryParameter.minqty);
                }
                if (orderQueryParameter.maxqty != null)
                {
                    query = query.Where(a => a.qty <= orderQueryParameter.maxqty);
                }

                if (orderQueryParameter.dtcreatedfrom != null)
                {
                    query = query.Where(a => a.dt_crtd >= orderQueryParameter.dtcreatedfrom);
                }
                if (orderQueryParameter.dtcreatedto != null)
                {
                    query = query.Where(a => a.dt_crtd <= orderQueryParameter.dtcreatedto);
                }
                if (query.Count() > 0)
                {
                    orders = query.OrderBy(b => b.id)
                    .Skip((orderQueryParameter.PageNumber - 1) * orderQueryParameter.PageSize)
                                            .Take(orderQueryParameter.PageSize).Select(a => new Order
                                            {
                                                dt_crtd = a.dt_crtd,
                                                id = a.id,
                                                cust_id = a.cust_id,
                                                del_meth_id = a.del_meth_id,
                                                qty = a.qty,
                                                remarks = a.remarks,
                                                total_amt   = a.total_amt,                                               
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
            return orders;
        }

        public List<OrderDetail> SearchOrderDetail(OrderDetailQueryParameter orderDetailQueryParameter)
        {
            List<OrderDetail> orderdetails = new List<OrderDetail>();
            try
            {
                var query = context.orderDetails.AsQueryable();
                query = query.Where(a => a.status == 1);
                if (orderDetailQueryParameter.orderid != null)
                {
                    query = query.Where(a => a.order_id == orderDetailQueryParameter.orderid);
                }
                if (orderDetailQueryParameter.inv_stock_id != null)
                {
                    query = query.Where(a => a.inv_stock_id == orderDetailQueryParameter.inv_stock_id);
                }

                if (orderDetailQueryParameter.min_unit_price != null)
                {
                    query = query.Where(a => a.unit_price >= orderDetailQueryParameter.min_unit_price);
                }
                if (orderDetailQueryParameter.max_unit_price != null)
                {
                    query = query.Where(a => a.unit_price <= orderDetailQueryParameter.max_unit_price);
                }

                if (orderDetailQueryParameter.min_line_total != null)
                {
                    query = query.Where(a => a.line_total >= orderDetailQueryParameter.min_line_total);
                }
                if (orderDetailQueryParameter.max_line_total != null)
                {
                    query = query.Where(a => a.line_total <= orderDetailQueryParameter.max_line_total);
                }

                if (orderDetailQueryParameter.dtcreatedfrom != null)
                {
                    query = query.Where(a => a.dt_crtd >= orderDetailQueryParameter.dtcreatedfrom);
                }
                if (orderDetailQueryParameter.dtcreatedto != null)
                {
                    query = query.Where(a => a.dt_crtd <= orderDetailQueryParameter.dtcreatedto);
                }
                if (query.Count() > 0)
                {
                    orderdetails = query.OrderBy(b => b.id)
                    .Skip((orderDetailQueryParameter.PageNumber - 1) * orderDetailQueryParameter.PageSize)
                                            .Take(orderDetailQueryParameter.PageSize).Select(a => new OrderDetail  
                                            {
                                                dt_crtd = a.dt_crtd,
                                                id = a.id,                                               
                                                qty = a.qty,
                                                inv_stock_id = a.inv_stock_id,
                                                line_total = a.line_total,
                                                order_id = a.order_id,
                                                unit_price  = a.unit_price,                                             
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
            return orderdetails;
        }
    }
}
