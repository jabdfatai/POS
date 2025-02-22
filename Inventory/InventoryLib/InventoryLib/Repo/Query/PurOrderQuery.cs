using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Server;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Repo.Query
{
    public class PurOrderQuery : IPurOrderQuery
    {
        InventoryDbContext context;
        ILogger<PurOrderQuery> logger;
        int resultid = 0;

        public PurOrderQuery(InventoryDbContext context, ILogger<PurOrderQuery> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Pur_Order GetPurchaseOrder(int purchaseorderid)
        {
            Pur_Order pur_Order = new Pur_Order();
            try
            {
                var query = context.Pur_Orders.Find(purchaseorderid);
                if (query == null)
                {
                    pur_Order = null;
                }
                else
                {
                    pur_Order = query;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return pur_Order;
        }
        public List<Pur_Order> SearchPurchaseOrder(Pur_OrdQueryParameters pur_OrdQueryParameters)
        {
            List<Pur_Order> puroederlist = new List<Pur_Order>();
            try
            {
                var result = context.Pur_Orders.Where(a => a.status == 1);

                if (pur_OrdQueryParameters.pur_ord_no != null)
                {
                    result = result.Where(a => a.pur_ord_no == pur_OrdQueryParameters.pur_ord_no);
                }
                if (pur_OrdQueryParameters.vend_id != null)
                {
                    result = result.Where(a => a.vend_id == pur_OrdQueryParameters.vend_id);
                }
                if (pur_OrdQueryParameters.min_purchase_date != null)
                {
                    result = result.Where(a => a.purchase_date >= pur_OrdQueryParameters.min_purchase_date);
                }

                if (pur_OrdQueryParameters.max_purchase_date != null)
                {
                    result = result.Where(a => a.purchase_date <= pur_OrdQueryParameters.max_purchase_date);
                }
                if (pur_OrdQueryParameters.mincost != null)
                {
                    result = result.Where(a => a.total_item_cost >= pur_OrdQueryParameters.mincost);
                }
                if (pur_OrdQueryParameters.maxcost != null)
                {
                    result = result.Where(a => a.total_item_cost <= pur_OrdQueryParameters.mincost);
                }

                if (pur_OrdQueryParameters.minqty != null)
                {
                    result = result.Where(a => a.total_item_no >= pur_OrdQueryParameters.minqty);
                }
                if (pur_OrdQueryParameters.maxqty != null)
                {
                    result = result.Where(a => a.total_item_no <= pur_OrdQueryParameters.maxqty);
                }

                if (pur_OrdQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= pur_OrdQueryParameters.dtcreatedfrom);
                }
                if (pur_OrdQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= pur_OrdQueryParameters.dtcreatedto);
                }
                if (result.Count() > 0)
                {
                    puroederlist = result.OrderBy(b => b.id)
                                            .Skip((pur_OrdQueryParameters.PageNumber - 1) * pur_OrdQueryParameters.PageSize)
                                            .Take(pur_OrdQueryParameters.PageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return puroederlist;
        }
    }
}
