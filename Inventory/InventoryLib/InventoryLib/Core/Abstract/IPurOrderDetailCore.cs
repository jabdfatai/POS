using InventoryLib.Model;
using InventoryLib.QueryParameters;
using Common.Model;
using InventoryLib.ViewModel;
using Common.Response;

namespace InventoryLib.Core.Abstract
{
    public interface IPurOrderDetailCore
    {
        CommandResponse AddPurchaseOrderDetail(Pur_Ord_DtlAddViewModel pur_Ord_DtlAddViewModel);
        CommandResponse UpdatePurchaseOrderDetail(int purchaseorderdtlid, Pur_Ord_DtlAddViewModel pur_Ord_DtlAddViewModel);

        CommandResponse DeletePurchaseOrderDetail(int purchaseorderdtlid);

        QueryResponse<CountModel<Pur_Ord_Dtl>> SearchPurchaseOrderDetail(Pur_Ord_DtlQueryParameters pur_Ord_DtlQueryParameters);
        QueryResponse<Pur_Ord_Dtl> GetPurchaseOrderDetail(int purchaseorderdtlid);
    }

}
