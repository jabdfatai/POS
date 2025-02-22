using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Abstract
{
    public interface IPurOrderDetailCommand
    {
        int AddPurchaseOrderDetail(Pur_Ord_DtlAddViewModel pur_Ord_DtlAddViewModel);
        int UpdatePurchaseOrderDetail(int purchaseorderdtlid, Pur_Ord_DtlAddViewModel pur_Ord_DtlAddViewModel);

        bool DeletePurchaseOrderDetail(int purchaseorderdtlid);
    }
    public interface IPurOrderDetailQuery
    {
        List<Pur_Ord_Dtl> SearchPurchaseOrderDetail(Pur_Ord_DtlQueryParameters pur_Ord_DtlQueryParameters);
        Pur_Ord_Dtl GetPurchaseOrderDetail(int purchaseorderdtlid);
    }
}
