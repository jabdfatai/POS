using InventoryLib.Model;
using InventoryLib.Server;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Repo.Command
{
    public class Pur_OrderCommand : IPurOrderCommand
    {
        InventoryDbContext context;
        ILogger<Pur_OrderCommand> logger;
        int resultid = 0;
        public Pur_OrderCommand(InventoryDbContext context, ILogger<Pur_OrderCommand> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public int AddPurchaseOrder(Pur_OrderAddViewModel pur_OrderAddViewModel)
        {
            try
            {
                context.Pur_Orders.Add(new Pur_Order
                {
                    purchase_date = pur_OrderAddViewModel.purchase_date,
                    pur_ord_no = pur_OrderAddViewModel.pur_ord_no,
                    total_item_cost = pur_OrderAddViewModel.total_item_cost,
                    total_item_no = pur_OrderAddViewModel.total_item_no,
                    vend_id = pur_OrderAddViewModel.vend_id

                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeletePurchaseOrder(int purchaseorderid)
        {

            bool deletestatus = false;
            try
            {

                var selpurorder = context.Pur_Orders.Find(purchaseorderid);
                selpurorder.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int UpdatePurchaseOrder(int purchaseorderid, Pur_OrderAddViewModel pur_OrderAddViewModel)
        {
            try
            {
                var selpurorder = context.Pur_Orders.Find(purchaseorderid);
                selpurorder.purchase_date = pur_OrderAddViewModel.purchase_date;
                selpurorder.pur_ord_no = pur_OrderAddViewModel.pur_ord_no;
                selpurorder.vend_id = pur_OrderAddViewModel.vend_id;
                selpurorder.total_item_cost = pur_OrderAddViewModel.total_item_cost;
                selpurorder.total_item_no = pur_OrderAddViewModel.total_item_no;
                selpurorder.dt_modf = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }
    }
}
