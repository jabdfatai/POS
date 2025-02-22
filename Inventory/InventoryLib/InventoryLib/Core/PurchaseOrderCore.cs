using Common.Model;
using Common.Response;
using InventoryLib.Core.Abstract;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo;
using InventoryLib.Repo.Abstract;
using InventoryLib.Repo.Command;
using InventoryLib.Repo.Query;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryLib.Core
{
    public class PurOrderCore : IPurOrderCore
    {
        IPurOrderCommand PurOrderCommand;
        IPurOrderQuery PurOrderQuery;
        ILogger<PurOrderCore> logger;
        public PurOrderCore(IPurOrderCommand PurOrderCommand,IPurOrderQuery PurOrderQuery,ILogger<PurOrderCore> logger)
        {
            this.PurOrderCommand = PurOrderCommand;
            this.PurOrderQuery = PurOrderQuery;
            this.logger = logger;
        }

        public CommandResponse AddPurchaseOrder(Pur_OrderAddViewModel PurOrderAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = PurOrderCommand.AddPurchaseOrder(PurOrderAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddPurchaseOrder)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeletePurchaseOrder(int PurOrderid)
        {
            bool result = false;
            try
            {
                result = PurOrderCommand.DeletePurchaseOrder(PurOrderid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeletePurchaseOrder)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Pur_Order> GetPurchaseOrder(int PurOrderid)
        {
            QueryResponse<Pur_Order> queryResponse = new QueryResponse<Pur_Order>();
            try
            {
                Pur_Order PurOrder = new Pur_Order();

                PurOrder = PurOrderQuery.GetPurchaseOrder(PurOrderid);

                if (PurOrder != null)
                {
                    queryResponse = QueryResponse<Pur_Order>.Load(PurOrder);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetPurchaseOrder)}");
            }
            return queryResponse;
        }

        public QueryResponse<CountModel<Pur_Order>> SearchPurchaseOrder(Pur_OrdQueryParameters PurOrderQueryParameters)
        {
            QueryResponse<CountModel<Pur_Order>> queryResponse = new QueryResponse<CountModel<Pur_Order>>();
            try
            {

                var list = PurOrderQuery.SearchPurchaseOrder(PurOrderQueryParameters);
                var plist = PagedList<Pur_Order>.ToPagedIList(list, PurOrderQueryParameters.PageNumber, PurOrderQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Pur_Order>>.Load(CountModel<Pur_Order>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(SearchPurchaseOrder)}");
            }
            return queryResponse;
        }

        public CommandResponse UpdatePurchaseOrder(int PurOrderid, Pur_OrderAddViewModel PurOrderAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = PurOrderCommand.UpdatePurchaseOrder(PurOrderid,PurOrderAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdatePurchaseOrder)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
