
using Common.Model;
using Common.Response;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;

namespace OrderFulfillmentLib.Core.Abstract
{
    public interface IOrderDeliveryCore
    {
        public CommandResponse AddOrderDelivery(OrderDeliveryAddViewModel orderDeliveryAddViewModel);

        public CommandResponse UpdateOrderDelivery(int id, OrderDeliveryPatchViewModel orderDeliveryPatchViewModel);
        public CommandResponse PatchOrderDelivery(int id, OrderDeliveryPatchViewModel orderDeliveryPatchViewModel);
        public CommandResponse DeleteOrderDelivery(int id);

        public QueryResponse<CountModel<OrderDelivery>> GetOrderDeliveries(OrderDeliveryQueryParameter orderDeliveryQueryParameter);

        public QueryResponse<OrderDelivery> GetOrderDelivery(int id);
    }



}
