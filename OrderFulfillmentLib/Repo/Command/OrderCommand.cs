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
    public class OrderCommand : IOrderCommand
    {

        OrderFulfillmentDbContext context;
        ILogger<OrderCommand> logger;
        int resultid = 0;
        public OrderCommand(OrderFulfillmentDbContext context,
        ILogger<OrderCommand> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public int AddOrder(Order order)
        {
            try
            {
                context.orders.Add(order);
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public int AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                context.orderDetails.Add(orderDetail);
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteOrder(int id)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.orders.Find(id);
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

        public bool DeleteOrderDetail(int id)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.orderDetails.Find(id);
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

        public int PatchOrder(int id, OrderPatchViewModel orderPatchViewModel)
        {
            try
            {
                var selrec = context.orders.Find(id);
                selrec.qty = orderPatchViewModel.qty == null ? selrec.qty : orderPatchViewModel.qty.Value;
                selrec.total_amt = orderPatchViewModel.total_amt == null ? selrec.total_amt : orderPatchViewModel.total_amt.Value;
                selrec.del_meth_id = orderPatchViewModel.del_meth_id == null ? selrec.del_meth_id : orderPatchViewModel.del_meth_id.Value;
                selrec.dt_modf = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }   
        public int PatchOrderDetail(int id, OrderDetailPatchViewModel orderDetailPatchViewModel)
        {
            try
            {
                var selrec = context.orderDetails.Find(id);
                selrec.qty = orderDetailPatchViewModel.qty == null ? selrec.qty : orderDetailPatchViewModel.qty.Value;
                selrec.line_total = orderDetailPatchViewModel.line_total == null ? selrec.line_total : orderDetailPatchViewModel.line_total.Value;
                selrec.unit_price = orderDetailPatchViewModel.unit_price == null ? selrec.unit_price : orderDetailPatchViewModel.unit_price.Value;
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
