using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Abstract
{
   public interface IInv_TranCommand
    {
        int AddInvTran(Inv_TransAddViewModel inv_TransAddViewModel);
        int UpdateInvTran(int inv_Tranid, Inv_TransAddViewModel inv_TransAddViewModel);
        int PatchInvTran(int inv_Tranid, Inv_TransPatchViewModel inv_TransPatchViewModel);
        bool DeleteInvTran(int inv_Tranid);
    }
    public interface IInv_TranQuery
    {
        List<Inv_TransViewModel> SearchInventoryTransaction(Inv_TransQueryParameters inv_TransQueryParameters);
        Inv_Tran GetInventoryTransaction(int inv_Tranid);
    }
}
