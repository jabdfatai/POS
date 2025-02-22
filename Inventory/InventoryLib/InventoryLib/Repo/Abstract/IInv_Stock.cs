using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Abstract
{
   public interface IInv_StockCommand
    {
        int AddInvStock(Inv_StockAddViewModel inv_StockAddViewModel);
        int UpdateInvStock(int inv_Stockid, Inv_StockAddViewModel inv_StockAddViewModel);
        int PatchInvStock(int inv_Stockid, Inv_StockPatchViewModel inv_StockAddViewModel);
        bool DeleteStock(int inv_Stockid);
    }
    public interface IInv_StockQuery
    {
        List<Inv_StockViewModel> SearchInventoryStock(Inv_StockQueryParameters inv_StockQueryParameters);
        Inv_Stock GetInventoryStock(int inv_Stockid);
    }
}
