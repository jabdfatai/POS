using Common.Model;
using Common.Response;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Core.Abstract
{
    public interface IInv_StockCore
    {

        public CommandResponse AddInvStock(Inv_StockAddViewModel inv_StockAddViewModel);

        public CommandResponse AddInvStockList(List<Inv_StockAddViewModel> inv_StockAddViewModellist);

        public CommandResponse DepleteInvStock(int inv_Stockid,int qty);
        public CommandResponse DepleteInvStockList(List<Inv_StockDepleteViewModel> inv_StockDepleteViewModels);

        public CommandResponse UpdateInvStock(int inv_Stockid, Inv_StockAddViewModel inv_StockAddViewModel);
        public CommandResponse PatchInvStock(int inv_Stockid, Inv_StockPatchViewModel inv_StockAddViewModel);
        public CommandResponse DeleteInvStock(int inv_Stockid);

        public QueryResponse<CountModel<Inv_StockViewModel>> SearchInventoryStock(Inv_StockQueryParameters inv_StockQueryParameters);

        public QueryResponse<Inv_Stock> GetInvStock(int inv_Stockid);


    }
  
}
