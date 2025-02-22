using InventoryLib.Model;
using InventoryLib.QueryParameters;
using Common.Model;
using InventoryLib.ViewModel;
using Common.Response;

namespace InventoryLib.Core.Abstract
{
    public interface IPurOrderCore
    {
        CommandResponse AddPurchaseOrder(Pur_OrderAddViewModel pur_OrderAddViewModel);
        CommandResponse UpdatePurchaseOrder(int purchaseorderid, Pur_OrderAddViewModel pur_OrderAddViewModel);

        CommandResponse DeletePurchaseOrder(int purchaseorderid);
        QueryResponse<CountModel<Pur_Order>> SearchPurchaseOrder(Pur_OrdQueryParameters pur_OrdQueryParameters);
        QueryResponse<Pur_Order> GetPurchaseOrder(int PurOrderid);
    }

}
