using Common.Response;
using Facade.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Facade
{
    public interface ISalesFacade
    {
        BarCodeScanViewModel GetScanProductDetails(string UPC);
        ApiResponse<CommandResponse> RecordSale(PosOrderModel posOrderModel);
        bool ReturnSale(PosOrderModel posOrderModel);
    }

    public class ItemDetail
    {
        public string SKU { get; set; }
        public int lotid { get; set; }
        public int inv_stock_id { get; set; }
        public decimal unit_price { get; set; }
        public int qty { get; set; }
        public decimal line_total { get; set; }
    }

    public class PosOrderModel
    {
        public string? orderrefno { get; set; }
        public List<ItemDetail> items { get; set; }
        public Guid? customerid { get; set; }
        public int totalqty { get; set; }
        public decimal total_amt { get; set; }
        public int userid { get; set; }
        public int del_meth_id { get; set; }
    }
}
