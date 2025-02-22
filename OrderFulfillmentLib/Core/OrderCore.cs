using Common.Model;
using Common.Response;
using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Core.Abstract;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.Repo.Command;
using OrderFulfillmentLib.Repo.Query;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Core
{
    public class OrderCore : IOrderCore
    {
        IOrderCommand orderCommand;
        IOrderQuery orderQuery;
        ILogger<OrderCore> logger;

        public OrderCore(IOrderCommand orderCommand, IOrderQuery orderQuery, ILogger<OrderCore> logger)
        {
            this.orderCommand = orderCommand;
            this.orderQuery = orderQuery;
            this.logger = logger;

        }
        public CommandResponse AddOrder(OrderAddViewModel orderAddViewModel)
        {
            int result = 0;
            CommandResponse commandResponse = new CommandResponse();
            string ordrefnostring = DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + new Random().Next(100000, 999999).ToString();
            try
            {
                var orderres = orderCommand.AddOrder(new Order
                {
                    cust_id = orderAddViewModel.cust_id,
                    del_meth_id = orderAddViewModel.del_meth_id,
                    qty = orderAddViewModel.qty,
                    remarks = orderAddViewModel.remarks,
                    total_amt = orderAddViewModel.total_amt,
                    order_ref_no = ordrefnostring

                });
                if (orderres > 0)
                {
                    foreach (var item in orderAddViewModel.orderDetailAddViewModels)
                    {
                        orderCommand.AddOrderDetail(new OrderDetail
                        {
                            inv_stock_id = item.inv_stock_id,
                            order_id = orderres,
                            qty = item.qty,
                            unit_price = item.unit_price,
                            line_total = item.line_total
                        });
                        result++;
                    }
                    commandResponse.ResponseValue = orderres;
                    commandResponse.misc = ordrefnostring;

                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddOrder)}");
            }
            return CommandResponse.Load(commandResponse);
        }

        public CommandResponse DeleteOrder(int id)
        {
            bool result = false;
            try
            {
                result = orderCommand.DeleteOrder(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteOrder)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse DeleteOrderDetail(int id)
        {

            bool result = false;
            try
            {
                result = orderCommand.DeleteOrderDetail(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteOrderDetail)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<OrderViewModel> GetOrder(int id)
        {
            QueryResponse<OrderViewModel> queryResponse = new QueryResponse<OrderViewModel>();
            OrderViewModel orderViewModel = new OrderViewModel();
            try
            {
                if (id > 0)
                {
                    Order order = orderQuery.GetOrder(id);
                    if (order != null)
                    {
                        orderViewModel.remarks = order.remarks;
                        orderViewModel.total_amt = order.total_amt;
                        orderViewModel.cust_id = order.cust_id;
                        orderViewModel.del_meth_id = order.del_meth_id;
                        orderViewModel.id = id;
                        orderViewModel.qty = order.qty;

                        var orddtl = orderQuery.GetOrderDetailByOrderId(id);
                        orderViewModel.orderDetailViewModels = orddtl.Select(a => new OrderDetailViewModel
                        {
                            id = a.id,
                            inv_stock_id = a.inv_stock_id,
                            qty = a.qty,
                            line_total = a.line_total,
                            order_id = a.order_id,
                            unit_price = a.unit_price
                        }).ToList();
                    }

                  
                    queryResponse = QueryResponse<OrderViewModel>.Load(orderViewModel);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetOrder)}");
            }


            return queryResponse;
        }

        public QueryResponse<OrderDetail> GetOrderDetail(int id)
        {
            QueryResponse<OrderDetail> queryResponse = new QueryResponse<OrderDetail>();
            try
            {
          
                if (id > 0)
                {
                    var orderdtl = orderQuery.GetOrderDetail(id);

                    queryResponse = QueryResponse<OrderDetail>.Load(orderdtl);
                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetOrderDetail)}");
            }


            return queryResponse;
        }

        public QueryResponse<CountModel<OrderDetail>> GetOrderDetails(OrderDetailQueryParameter orderDetailQueryParameter)
        {
            QueryResponse<CountModel<OrderDetail>> queryResponse = new QueryResponse<CountModel<OrderDetail>>();
            try
            {

                var list = orderQuery.SearchOrderDetail(orderDetailQueryParameter);
                var plist = PagedList<OrderDetail>.ToPagedIList(list, orderDetailQueryParameter.PageNumber, orderDetailQueryParameter.PageSize);
                queryResponse = QueryResponse<CountModel<OrderDetail>>.Load(CountModel<OrderDetail>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetOrderDetails)}");
            }
            return queryResponse;
        }

        public QueryResponse<CountModel<Order>> GetOrders(OrderQueryParameter orderQueryParameter)
        {
            QueryResponse<CountModel<Order>> queryResponse = new QueryResponse<CountModel<Order>>();
            try
            {

                var list = orderQuery.SearchOrder(orderQueryParameter);
                var plist = PagedList<Order>.ToPagedIList(list, orderQueryParameter.PageNumber, orderQueryParameter.PageSize);
                queryResponse = QueryResponse<CountModel<Order>>.Load(CountModel<Order>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetOrders)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchOrder(int id, OrderPatchViewModel orderPatchViewModel)
        {
            int result = 0;
            try
            {
                result = orderCommand.PatchOrder(id, orderPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchOrder)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse PatchOrderDetail(int orderdetailid, OrderDetailPatchViewModel orderDetailPatchViewModel)
        {
            int result = 0;
            try
            {
                result = orderCommand.PatchOrderDetail(orderdetailid, orderDetailPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchOrderDetail)}");
            }
            return CommandResponse.Load(result);
        }
    }
}
