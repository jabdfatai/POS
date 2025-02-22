using InventoryLib.Model;
using InventoryLib.Repo.Abstract;
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
    public class Pur_OrderDtlCommand : IPurOrderDetailCommand
    {
        InventoryDbContext context;
        ILogger<Pur_OrderDtlCommand> logger;
        int resultid = 0;
        public Pur_OrderDtlCommand(InventoryDbContext context, ILogger<Pur_OrderDtlCommand> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public int AddPurchaseOrderDetail(Pur_Ord_DtlAddViewModel pur_Ord_DtlAddViewModel)
        {
            try
            {
                context.Pur_Ord_Dtls.Add(new Pur_Ord_Dtl
                {
                    prod_id = pur_Ord_DtlAddViewModel.prod_id,
                    note = pur_Ord_DtlAddViewModel.note,
                    pur_ord_id = pur_Ord_DtlAddViewModel.pur_ord_id,
                    unit_cost = pur_Ord_DtlAddViewModel.unit_cost,
                    qty = pur_Ord_DtlAddViewModel.qty,
                    line_total = pur_Ord_DtlAddViewModel.line_total

                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeletePurchaseOrderDetail(int purchaseorderdtlid)
        {

            bool deletestatus = false;
            try
            {

                var selpurorderdtl = context.Pur_Ord_Dtls.Find(purchaseorderdtlid);
                selpurorderdtl.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int UpdatePurchaseOrderDetail(int purchaseorderdtlid, Pur_Ord_DtlAddViewModel pur_Ord_DtlAddViewModel)
        {
            try
            {
                var selpurorderdtl = context.Pur_Ord_Dtls.Find(purchaseorderdtlid);
                selpurorderdtl.note = pur_Ord_DtlAddViewModel.note;
                selpurorderdtl.prod_id = pur_Ord_DtlAddViewModel.prod_id;
                selpurorderdtl.pur_ord_id = pur_Ord_DtlAddViewModel.pur_ord_id;
                selpurorderdtl.line_total = pur_Ord_DtlAddViewModel.line_total;
                selpurorderdtl.qty = pur_Ord_DtlAddViewModel.qty;
                selpurorderdtl.unit_cost = pur_Ord_DtlAddViewModel.unit_cost;
                selpurorderdtl.dt_modf = DateTime.UtcNow;
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
