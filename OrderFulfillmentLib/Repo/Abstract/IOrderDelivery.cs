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
    public interface IOrderDeliveryCommand
    {
        int AddOrderDelivery(OrderDelivery orderDelivery);
        int PatchOrderDelivery(int id, OrderDeliveryPatchViewModel orderDeliveryPatchViewModel);
        bool DeleteOrderDelivery(int id);
    }
    public interface IOrderDeliveryQuery
    {
        List<OrderDelivery> SearchOrderDelivery(OrderDeliveryQueryParameter orderDeliveryQueryParameter);
        OrderDelivery GetOrderDelivery(int id);
    }
}
