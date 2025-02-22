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
    public class Inv_TranCore : IInv_TranCore
    {
  
        IInv_TranCommand inv_TranCommand;
        IInv_TranQuery inv_TranQuery;
        ILogger<Inv_TranCore> logger;

        public Inv_TranCore(IInv_TranCommand inv_TranCommand, IInv_TranQuery inv_TranQuery,ILogger<Inv_TranCore> logger)
        {
            this.inv_TranQuery = inv_TranQuery;
            this.inv_TranCommand = inv_TranCommand;
            this.logger = logger;
        }
        public CommandResponse AddInvTran(Inv_TransAddViewModel inv_TransAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = inv_TranCommand.AddInvTran(inv_TransAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddInvTran)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteInvTran(int inv_Tranid)
        {
            bool result = false;
            try
            {
                result = inv_TranCommand.DeleteInvTran(inv_Tranid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddInvTran)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Inv_Tran> GetInventoryTransaction(int inv_Tranid)
        {
            QueryResponse<Inv_Tran> queryResponse = new QueryResponse<Inv_Tran>();
            try
            {
                Inv_Tran inv_Tran = new Inv_Tran();
                if (inv_Tran != null)
                {
                    inv_Tran = inv_TranQuery.GetInventoryTransaction(inv_Tranid);


                    queryResponse = QueryResponse<Inv_Tran>.Load(inv_Tran);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetInventoryTransaction)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchInvTran(int inv_Tranid, Inv_TransPatchViewModel inv_TransPatchViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = inv_TranCommand.PatchInvTran(inv_Tranid, inv_TransPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddInvTran)}");
            }
            return CommandResponse.Load(resultid);
        }

        public QueryResponse<CountModel<Inv_TransViewModel>> SearchInventoryTransaction(Inv_TransQueryParameters inv_TransQueryParameters)
        {
            QueryResponse<CountModel<Inv_TransViewModel>> queryResponse = new QueryResponse<CountModel<Inv_TransViewModel>>();
            try
            {

                var list = inv_TranQuery.SearchInventoryTransaction(inv_TransQueryParameters);
                var plist = PagedList<Inv_TransViewModel>.ToPagedIList(list, inv_TransQueryParameters.PageNumber, inv_TransQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Inv_TransViewModel>>.Load(CountModel<Inv_TransViewModel>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(SearchInventoryTransaction)}");
            }
            return queryResponse;
        }

        public CommandResponse UpdateInvTran(int inv_Tranid, Inv_TransAddViewModel inv_TransAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = inv_TranCommand.UpdateInvTran(inv_Tranid, inv_TransAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddInvTran)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
