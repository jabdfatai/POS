using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Repo.Abstract
{
    public interface IOrderCommand
    {
        int AddOrder(Order order);

        int PatchOrder(int id, OrderPatchViewModel orderPatchViewModel);
        bool DeleteOrder(int id);

        int AddOrderDetail(OrderDetail orderDetail);

        int PatchOrderDetail(int id, OrderDetailPatchViewModel orderDetailPatchViewModel);
        bool DeleteOrderDetail(int id);
    }
    public interface IOrderQuery
    {
        List<Order> SearchOrder(OrderQueryParameter orderQueryParameter);
        Order GetOrder(int id);
        List<OrderDetail> SearchOrderDetail(OrderDetailQueryParameter orderDetailQueryParameter);
        OrderDetail GetOrderDetail(int id);

        List<OrderDetail> GetOrderDetailByOrderId(int orderid);
    }
}
