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
    public class Inv_StockCore : IInv_StockCore
    {
        IInv_StockCommand Inv_StockCommand;
        IInv_TranCommand Inv_TranCommand;
        IInv_StockQuery inv_StockQuery;
        ILogger<Inv_StockCore> logger;

        public Inv_StockCore(IInv_StockCommand Inv_StockCommand, IInv_StockQuery inv_StockQuery, IInv_TranCommand Inv_TranCommand, ILogger<Inv_StockCore> logger)
        {
            this.inv_StockQuery = inv_StockQuery;
            this.Inv_StockCommand = Inv_StockCommand;
            this.Inv_TranCommand = Inv_TranCommand;
            this.logger = logger;

        }


        public CommandResponse AddInvStock(Inv_StockAddViewModel inv_StockAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = Inv_StockCommand.AddInvStock(inv_StockAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddInvStock)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse AddInvStockList(List<Inv_StockAddViewModel> inv_StockAddViewModellist)
        {
            int resultid = 0;
            try
            {
                foreach (var item in inv_StockAddViewModellist)
                {
                    var res = Inv_StockCommand.AddInvStock(item);
                    resultid++;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddInvStock)}");
            }
            return CommandResponse.Load(resultid);
        }


        public CommandResponse DeleteInvStock(int inv_Stockid)
        {
            bool result = false;
            try
            {
                result = Inv_StockCommand.DeleteStock(inv_Stockid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteInvStock)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse DepleteInvStock(int inv_Stockid, int qty)
        {
            int result = 0;
            CommandResponse commandResponse = new CommandResponse();
            try
            {
                var invstock = inv_StockQuery.GetInventoryStock(inv_Stockid);
                if (invstock != null)
                {
                    int remainingqty = invstock.qty - qty;
                    result = Inv_StockCommand.PatchInvStock(inv_Stockid, new Inv_StockPatchViewModel { qty = remainingqty });


                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteInvStock)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse DepleteInvStockList(List<Inv_StockDepleteViewModel> inv_StockDepleteViewModels)
        {
            int result = 0;
            CommandResponse commandResponse = new CommandResponse();
            try
            {
                foreach (var item in inv_StockDepleteViewModels)
                {
                    var invstock = inv_StockQuery.GetInventoryStock(item.inv_Stockid);
                    if (invstock != null)
                    {
                        int remainingqty = invstock.qty - item.qty;
                        var invtranres = Inv_TranCommand.AddInvTran(new Inv_TransAddViewModel
                        {
                            dir = 1,
                            inv_stock_id = item.inv_Stockid,
                            note = "",
                            qty = item.qty,
                            lot_id = item.lotid.Value
                        });
                        var res = Inv_StockCommand.PatchInvStock(item.inv_Stockid, new Inv_StockPatchViewModel { qty = remainingqty });
                        result++;


                    }
                }



            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteInvStock)}");
            }
            return CommandResponse.Load(result);
        }


        public QueryResponse<Inv_Stock> GetInvStock(int inv_Stockid)
        {
            QueryResponse<Inv_Stock> queryResponse = new QueryResponse<Inv_Stock>();
            try
            {
                Inv_Stock inv_stock = new Inv_Stock();
                if (inv_Stockid > 0)
                {
                    inv_stock = inv_StockQuery.GetInventoryStock(inv_Stockid);

                    if (inv_stock != null)
                    {
                        queryResponse = QueryResponse<Inv_Stock>.Load(inv_stock);
                    }

                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetInvStock)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchInvStock(int inv_Stockid, Inv_StockPatchViewModel inv_StockAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = Inv_StockCommand.PatchInvStock(inv_Stockid, inv_StockAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchInvStock)}");
            }
            return CommandResponse.Load(resultid);
        }



        public CommandResponse UpdateInvStock(int inv_Stockid, Inv_StockAddViewModel inv_StockAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = Inv_StockCommand.UpdateInvStock(inv_Stockid, inv_StockAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateInvStock)}");
            }
            return CommandResponse.Load(resultid);
        }

        QueryResponse<CountModel<Inv_StockViewModel>> IInv_StockCore.SearchInventoryStock(Inv_StockQueryParameters inv_StockQueryParameters)
        {
            QueryResponse<CountModel<Inv_StockViewModel>> queryResponse = new QueryResponse<CountModel<Inv_StockViewModel>>();
            try
            {

                var list = inv_StockQuery.SearchInventoryStock(inv_StockQueryParameters);
                var plist = PagedList<Inv_StockViewModel>.ToPagedIList(list, inv_StockQueryParameters.PageNumber, inv_StockQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Inv_StockViewModel>>.Load(CountModel<Inv_StockViewModel>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(IInv_StockCore.SearchInventoryStock)}");
            }
            return queryResponse;
        }
    }
}
