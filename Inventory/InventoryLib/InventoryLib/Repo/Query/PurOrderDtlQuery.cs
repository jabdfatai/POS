using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo.Abstract;
using InventoryLib.Server;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Repo.Query
{
    public class PurOrderDtlQuery : IPurOrderDetailQuery
    {
        InventoryDbContext context;
        ILogger<PurOrderDtlQuery> logger;
        int resultid = 0;
        public PurOrderDtlQuery(InventoryDbContext context,ILogger<PurOrderDtlQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public Pur_Ord_Dtl GetPurchaseOrderDetail(int purchaseorderdtlid)
        {
            Pur_Ord_Dtl pur_Ord_Dtl = new Pur_Ord_Dtl();
            try
            {
                var query = context.Pur_Ord_Dtls.Find(purchaseorderdtlid);
                if (query == null)
                {
                    pur_Ord_Dtl = null;
                }
                else
                {
                    pur_Ord_Dtl = query;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return pur_Ord_Dtl;
        }

        public List<Pur_Ord_Dtl> SearchPurchaseOrderDetail(Pur_Ord_DtlQueryParameters pur_Ord_DtlQueryParameters)
        {
            List<Pur_Ord_Dtl> puroorderdtllist = new List<Pur_Ord_Dtl>();
            try
            {
                var result = context.Pur_Ord_Dtls.Where(a => a.status == 1);

                if (pur_Ord_DtlQueryParameters.prod_id != null)
                {
                    result = result.Where(a => a.prod_id == pur_Ord_DtlQueryParameters.prod_id);
                }
                if (pur_Ord_DtlQueryParameters.pur_ord_id != null)
                {
                    result = result.Where(a => a.pur_ord_id == pur_Ord_DtlQueryParameters.pur_ord_id);
                }
              
                if (pur_Ord_DtlQueryParameters.mincost != null)
                {
                    result = result.Where(a => a.line_total >= pur_Ord_DtlQueryParameters.mincost);
                }
                if (pur_Ord_DtlQueryParameters.maxcost != null)
                {
                    result = result.Where(a => a.line_total <= pur_Ord_DtlQueryParameters.maxcost);
                }

                if (pur_Ord_DtlQueryParameters.minqty != null)
                {
                    result = result.Where(a => a.qty >= pur_Ord_DtlQueryParameters.minqty);
                }
                if (pur_Ord_DtlQueryParameters.maxqty != null)
                {
                    result = result.Where(a => a.qty <= pur_Ord_DtlQueryParameters.maxqty);
                }

                if (pur_Ord_DtlQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= pur_Ord_DtlQueryParameters.dtcreatedfrom);
                }
                if (pur_Ord_DtlQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= pur_Ord_DtlQueryParameters.dtcreatedto);
                }
                if (result.Count() > 0)
                {
                    puroorderdtllist = result.OrderBy(b => b.id)
                                            .Skip((pur_Ord_DtlQueryParameters.PageNumber - 1) * pur_Ord_DtlQueryParameters.PageSize)
                                            .Take(pur_Ord_DtlQueryParameters.PageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return puroorderdtllist;
        }
    }
}
