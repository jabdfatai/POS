using Common.Model;
using Common.Response;
using InventoryLib.Core.Abstract;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
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
    public class PurOrderDetailCore : IPurOrderDetailCore
    {
        IPurOrderDetailCommand PurOrderDetailCommand;
        IPurOrderDetailQuery PurOrderDetailQuery;
        ILogger<PurOrderDetailCore> logger;
        public PurOrderDetailCore(IPurOrderDetailCommand PurOrderDetailCommand,IPurOrderDetailQuery PurOrderDetailQuery,ILogger<PurOrderDetailCore> logger)
        {
            this.PurOrderDetailCommand = PurOrderDetailCommand;
            this.PurOrderDetailQuery = PurOrderDetailQuery;
            this.logger = logger;
        }

        public CommandResponse AddPurchaseOrderDetail(Pur_Ord_DtlAddViewModel PurOrderDetailAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = PurOrderDetailCommand.AddPurchaseOrderDetail(PurOrderDetailAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddPurchaseOrderDetail)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeletePurchaseOrderDetail(int PurOrderDetailid)
        {
            bool result = false;
            try
            {
                result = PurOrderDetailCommand.DeletePurchaseOrderDetail(PurOrderDetailid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeletePurchaseOrderDetail)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Pur_Ord_Dtl> GetPurchaseOrderDetail(int PurOrderDetailid)
        {
            QueryResponse<Pur_Ord_Dtl> queryResponse = new QueryResponse<Pur_Ord_Dtl>();
            try
            {
                Pur_Ord_Dtl PurOrderDetail = new Pur_Ord_Dtl();

                PurOrderDetail = PurOrderDetailQuery.GetPurchaseOrderDetail(PurOrderDetailid);

                if (PurOrderDetail != null)
                {
                    queryResponse = QueryResponse<Pur_Ord_Dtl>.Load(PurOrderDetail);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetPurchaseOrderDetail)}");
            }
            return queryResponse;
        }

        public QueryResponse<CountModel<Pur_Ord_Dtl>> SearchPurchaseOrderDetail(Pur_Ord_DtlQueryParameters PurOrderDetailQueryParameters)
        {
            QueryResponse<CountModel<Pur_Ord_Dtl>> queryResponse = new QueryResponse<CountModel<Pur_Ord_Dtl>>();
            try
            {

                var list = PurOrderDetailQuery.SearchPurchaseOrderDetail(PurOrderDetailQueryParameters);
                var plist = PagedList<Pur_Ord_Dtl>.ToPagedIList(list, PurOrderDetailQueryParameters.PageNumber, PurOrderDetailQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Pur_Ord_Dtl>>.Load(CountModel<Pur_Ord_Dtl>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(SearchPurchaseOrderDetail)}");
            }
            return queryResponse;
        }

        public CommandResponse UpdatePurchaseOrderDetail(int PurOrderDetailid, Pur_Ord_DtlAddViewModel PurOrderDetailAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = PurOrderDetailCommand.UpdatePurchaseOrderDetail(PurOrderDetailid,PurOrderDetailAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdatePurchaseOrderDetail)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
