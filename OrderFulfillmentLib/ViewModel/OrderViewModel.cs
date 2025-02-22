using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.ViewModel
{

    public class OrderAddViewModel
    {
        public int qty { get; set; }
        public decimal total_amt { get; set; }
        public Guid? cust_id { get; set; }
        public string? remarks { get; set; }
        public int del_meth_id { get; set; }
        public List<OrderDetailAddViewModel> orderDetailAddViewModels { get; set; }
        public OrderAddViewModel()
        {
            this.orderDetailAddViewModels = new List<OrderDetailAddViewModel>();
        }
    }
    public class OrderViewModel
    {
        public int id { get; set; }
        public int qty { get; set; }
        public decimal total_amt { get; set; }
        public Guid? cust_id { get; set; }
        public string? remarks { get; set; }
        public int del_meth_id { get; set; }
        public List<OrderDetailViewModel> orderDetailViewModels { get; set; }
        public OrderViewModel()
        {
            this.orderDetailViewModels = new List<OrderDetailViewModel>();
        }
    }

    public class OrderDetailViewModel
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int inv_stock_id { get; set; }
        public decimal unit_price { get; set; }
        public int qty { get; set; }
        public decimal line_total { get; set; }
    }

    public class OrderDetailAddViewModel
    {
       // public int order_id { get; set; }
        public int inv_stock_id { get; set; }
        public decimal unit_price { get; set; }
        public int qty { get; set; }
        public decimal line_total { get; set; }
        public int? lotid { get; set; }
    }

    public class OrderPatchViewModel
    {
        public int? qty { get; set; }
        public decimal? total_amt { get; set; }
        public int? del_meth_id { get; set; }
    }
    public class OrderDetailPatchViewModel
    {
        public decimal? unit_price { get; set; }
        public int? qty { get; set; }
        public decimal? line_total { get; set; }
    }
}
