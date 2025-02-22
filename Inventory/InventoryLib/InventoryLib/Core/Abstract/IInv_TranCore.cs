using Common.Response;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
using Common.Model;
using InventoryLib.ViewModel;

namespace InventoryLib.Core.Abstract
{
    public interface IInv_TranCore
    {
        public CommandResponse AddInvTran(Inv_TransAddViewModel inv_TransAddViewModel);
        public CommandResponse UpdateInvTran(int inv_Tranid, Inv_TransAddViewModel inv_TransAddViewModel);
        public CommandResponse PatchInvTran(int inv_Tranid, Inv_TransPatchViewModel inv_TransPatchViewModel);
        public CommandResponse DeleteInvTran(int inv_Tranid);

        public QueryResponse<CountModel<Inv_TransViewModel>> SearchInventoryTransaction(Inv_TransQueryParameters inv_TransQueryParameters);
        public QueryResponse<Inv_Tran> GetInventoryTransaction(int inv_Tranid);


    }
  
}
