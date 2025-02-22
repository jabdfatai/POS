
using Common.Model;
using Common.Response;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;

namespace OrderFulfillmentLib.Core.Abstract
{
    public interface IOrderCore
    {
        public CommandResponse AddOrder(OrderAddViewModel orderAddViewModel);

        public CommandResponse PatchOrder(int id, OrderPatchViewModel orderPatchViewModel);
        public CommandResponse PatchOrderDetail(int orderdetailid, OrderDetailPatchViewModel orderDetailPatchViewModel);
        public CommandResponse DeleteOrder(int id);
        public CommandResponse DeleteOrderDetail(int id);

        public QueryResponse<CountModel<Order>> GetOrders(OrderQueryParameter orderQueryParameter);

        public QueryResponse<OrderViewModel> GetOrder(int id);

        public QueryResponse<CountModel<OrderDetail>> GetOrderDetails(OrderDetailQueryParameter orderDetailQueryParameter);

        public QueryResponse<OrderDetail> GetOrderDetail(int id);
    }



}
