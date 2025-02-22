using Common.Response;
using Facade.ViewModel;
using InventoryLib.Core.Abstract;
using InventoryLib.Facade;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Core;
using OrderFulfillmentLib.Core.Abstract;
using OrderFulfillmentLib.Repo.Command;
using OrderFulfillmentLib.ViewModel;
using POSLib.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Concrete
{
    public class SalesFacade : ISalesFacade
    {
        IOrderCore orderCore;
        IInv_StockCore inv_StockCore;
        IBarConfigCore barConfigCore;
        ILogger<ISalesFacade> logger;
        public SalesFacade(IOrderCore orderCore, IInv_StockCore inv_StockCore, IBarConfigCore barConfigCore, ILogger<ISalesFacade> logger)
        {
            this.orderCore = orderCore;
            this.inv_StockCore = inv_StockCore;
            this.barConfigCore = barConfigCore;
            this.logger = logger;
        }

        public BarCodeScanViewModel GetScanProductDetails(string UPC)
        {
            BarCodeScanViewModel barCodeScanViewModel = new BarCodeScanViewModel();
            try
            {
                var barconfig = barConfigCore.GetBarConfigs(new POSLib.QueryParameters.Bar_ConfigQueryParameters { UPC = UPC });
                if (barconfig.HasResult)
                {
                   
                  
                    var invstock = inv_StockCore.SearchInventoryStock(new InventoryLib.QueryParameters.Inv_StockQueryParameters
                    {
                        SKU = barconfig.Data.Items.FirstOrDefault().SKU
                    });
                    if (invstock.HasResult)
                    {
                        barCodeScanViewModel.UPC = UPC;
                        barCodeScanViewModel.SKU = barconfig.Data.Items.FirstOrDefault().SKU;
                        barCodeScanViewModel.inv_stock_id = invstock.Data.Items.First().id;
                        barCodeScanViewModel.lotid = barconfig.Data.Items.First().lotid;
                      
                    }

                }
            }
            catch (Exception ex) { 
            
            }
            return barCodeScanViewModel;

        }

        public ApiResponse<CommandResponse> RecordSale(PosOrderModel posOrderModel)
        {
            var resp = ApiResponse<CommandResponse>.Failed("");

            var itemlist = posOrderModel.items.Select(a => new OrderDetailAddViewModel
            {
                unit_price = a.unit_price,
                qty = a.qty,
                line_total = a.line_total,
                inv_stock_id = a.inv_stock_id,
                lotid = a.lotid

            }).ToList();

            try
            {
                var res = orderCore.AddOrder(new OrderAddViewModel
                {
                    cust_id = posOrderModel.customerid,
                    del_meth_id = posOrderModel.del_meth_id,
                    orderDetailAddViewModels = itemlist,
                    qty = posOrderModel.totalqty,
                    total_amt = posOrderModel.total_amt

                });
                if (res.IsSuccessful)
                {
                    var invupdateres = inv_StockCore.DepleteInvStockList(itemlist.Select(a => new Inv_StockDepleteViewModel
                    {
                        inv_Stockid = a.inv_stock_id,
                        lotid = a.lotid,
                        qty = a.qty
                    }).ToList());

                    if (invupdateres.IsSuccessful)
                    {
                        resp = ApiResponse<CommandResponse>.Success(res);
                    }

                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
            return resp;
        }

        public bool ReturnSale(PosOrderModel posOrderModel)
        {
            throw new NotImplementedException();
        }
    }
}
