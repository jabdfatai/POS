
using Common.Model;
using Common.Response;
using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Core.Abstract;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Core
{
    public class OrderDeliveryCore : IOrderDeliveryCore
    {
        IOrderDeliveryCommand OrderDeliveryCommand;
        IOrderDeliveryQuery OrderDeliveryQuery;
        ILogger<OrderDeliveryCore> logger;
        public OrderDeliveryCore(IOrderDeliveryCommand OrderDeliveryCommand, IOrderDeliveryQuery OrderDeliveryQuery, ILogger<OrderDeliveryCore> logger)
        {
            this.OrderDeliveryQuery = OrderDeliveryQuery;
            this.logger = logger;
            this.OrderDeliveryCommand = OrderDeliveryCommand;

        }
        public CommandResponse AddOrderDelivery(OrderDeliveryAddViewModel OrderDeliveryAddViewModel)
        {
            int result = 0;
            try
            {
                result = OrderDeliveryCommand.AddOrderDelivery(new OrderDelivery
                {
                  add_line1 = OrderDeliveryAddViewModel.add_line1,
                  add_line2 = OrderDeliveryAddViewModel.add_line2,
                  city = OrderDeliveryAddViewModel.city,
                  contact_email = OrderDeliveryAddViewModel.contact_email,
                  contact_name = OrderDeliveryAddViewModel.contact_name,
                  contact_phone = OrderDeliveryAddViewModel.contact_phone,
                  country   = OrderDeliveryAddViewModel.country,
                  del_status = OrderDeliveryAddViewModel.del_status,    
                  state = OrderDeliveryAddViewModel.state,
                  zipcode = OrderDeliveryAddViewModel.zipcode,
                    order_id = OrderDeliveryAddViewModel.order_id
                   
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddOrderDelivery)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse DeleteOrderDelivery(int OrderDeliveryid)
        {
            bool result = false;
            try
            {
                result = OrderDeliveryCommand.DeleteOrderDelivery(OrderDeliveryid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteOrderDelivery)}");
            }
            return CommandResponse.Load(result);
        }
 
        public QueryResponse<CountModel<OrderDelivery>> GetOrderDeliveries(OrderDeliveryQueryParameter orderDeliveryQueryParameter)
        {
            QueryResponse<CountModel<OrderDelivery>> queryResponse = new QueryResponse<CountModel<OrderDelivery>>();
            try
            {

                var list = OrderDeliveryQuery.SearchOrderDelivery(orderDeliveryQueryParameter);
                var plist = PagedList<OrderDelivery>.ToPagedIList(list, orderDeliveryQueryParameter.PageNumber, orderDeliveryQueryParameter.PageSize);
                queryResponse = QueryResponse<CountModel<OrderDelivery>>.Load(CountModel<OrderDelivery>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetOrderDeliveries)}");
            }
            return queryResponse;
        }

        public QueryResponse<OrderDelivery> GetOrderDelivery(int OrderDeliveryid)
        {
            QueryResponse<OrderDelivery> queryResponse = new QueryResponse<OrderDelivery>();
            try
            {
                OrderDelivery OrderDelivery = new OrderDelivery();
                if (OrderDeliveryid != null)
                {
                    OrderDelivery = OrderDeliveryQuery.GetOrderDelivery(OrderDeliveryid);
                    queryResponse = QueryResponse<OrderDelivery>.Load(OrderDelivery);
                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetOrderDelivery)}");
            }


            return queryResponse;
        }

   

        public CommandResponse PatchOrderDelivery(int OrderDeliveryid, OrderDeliveryPatchViewModel OrderDeliveryPatchViewModel)
        {
            int result = 0;
            try
            {
                result = OrderDeliveryCommand.PatchOrderDelivery(OrderDeliveryid, OrderDeliveryPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchOrderDelivery)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse UpdateOrderDelivery(int OrderDeliveryid, OrderDeliveryPatchViewModel OrderDeliveryPatchViewModel)
        {
            int result = 0;
            try
            {
                result = OrderDeliveryCommand.PatchOrderDelivery(OrderDeliveryid, OrderDeliveryPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchOrderDelivery)}");
            }
            return CommandResponse.Load(result);
        }

    
    }
}
