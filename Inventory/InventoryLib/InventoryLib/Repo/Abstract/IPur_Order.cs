using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo
{
    public interface IPurOrderCommand
    {
        int AddPurchaseOrder(Pur_OrderAddViewModel pur_OrderAddViewModel);
        int UpdatePurchaseOrder(int purchaseorderid, Pur_OrderAddViewModel pur_OrderAddViewModel);
     
        bool DeletePurchaseOrder(int purchaseorderid);
    }
    public interface IPurOrderQuery
    {
        List<Pur_Order> SearchPurchaseOrder(Pur_OrdQueryParameters pur_OrdQueryParameters);
        Pur_Order GetPurchaseOrder(int purchaseorderid);
    }
}
