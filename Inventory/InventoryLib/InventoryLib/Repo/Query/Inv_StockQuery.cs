using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo.Abstract;
using InventoryLib.Repo.Command;
using InventoryLib.Server;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Repo.Query
{
    public class Inv_StockQuery : IInv_StockQuery
    {
        InventoryDbContext context;
        ILogger<Inv_StockQuery> logger;
        int resultid = 0;

        public Inv_StockQuery(InventoryDbContext context, ILogger<Inv_StockQuery> logger)
        {

            this.context = context;
            this.logger = logger;
        }
        public Inv_Stock GetInventoryStock(int inv_Stockid)
        {
            Inv_Stock invstock = new Inv_Stock();
            try
            {
                var query = context.Inv_Stocks.Find(inv_Stockid);
                if (query == null)
                {
                    invstock = null;
                }
                else
                {
                    invstock = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return invstock;

        }

        public List<Inv_StockViewModel> SearchInventoryStock(Inv_StockQueryParameters inv_StockQueryParameters)
        {

            List<Inv_StockViewModel> invstocklist = new List<Inv_StockViewModel>();
            try
            {
                var result = from a in context.Inv_Stocks
                             join b in context.Products on a.prod_id equals b.id into stockprodGroup
                             from c in stockprodGroup.DefaultIfEmpty()
                             join d in context.Prod_Types on c.prod_type_id equals d.id into prodGroup
                             from e in prodGroup.DefaultIfEmpty()
                             where a.status == 1
                             select new
                             {
                                 id = a.id,
                                 prod_id = a.prod_id,
                                 targ_inv_level = a.targ_inv_level,
                                 qty = a.qty,
                                 SKU = a.SKU,
                                 dt_crtd = a.dt_crtd,
                                 productname = c.descr,
                                 prodtype = e.descr,
                                 uom = c.uomid

                             };

                if (inv_StockQueryParameters.qty != null)
                {
                    result = result.Where(a => a.qty == inv_StockQueryParameters.qty);
                }
                if (inv_StockQueryParameters.prod_id != null)
                {
                    result = result.Where(a => a.prod_id == inv_StockQueryParameters.prod_id);
                }
                if (inv_StockQueryParameters.minqty != null)
                {
                    result = result.Where(a => a.qty >= inv_StockQueryParameters.minqty);
                }
                if (inv_StockQueryParameters.maxqty != null)
                {
                    result = result.Where(a => a.qty <= inv_StockQueryParameters.maxqty);
                }
                if (inv_StockQueryParameters.targ_inv_level != null)
                {
                    result = result.Where(a => a.targ_inv_level == inv_StockQueryParameters.targ_inv_level);
                }
                if (inv_StockQueryParameters.min_targ_inv_level != null)
                {
                    result = result.Where(a => a.targ_inv_level >= inv_StockQueryParameters.min_targ_inv_level);
                }
                if (inv_StockQueryParameters.max_targ_inv_level != null)
                {
                    result = result.Where(a => a.targ_inv_level <= inv_StockQueryParameters.max_targ_inv_level);
                }
                if (inv_StockQueryParameters.below_tar_inv_level != null)
                {
                    result = result.Where(a => a.qty <= inv_StockQueryParameters.targ_inv_level);
                }
                if (inv_StockQueryParameters.above_tar_inv_level != null)
                {
                    result = result.Where(a => a.qty >= inv_StockQueryParameters.targ_inv_level);
                }
                if (inv_StockQueryParameters.SKU != null)
                {
                    result = result.Where(a => a.SKU == inv_StockQueryParameters.SKU);
                }
                if (inv_StockQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= inv_StockQueryParameters.dtcreatedfrom);
                }
                if (inv_StockQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= inv_StockQueryParameters.dtcreatedto);
                }
                if (result != null)
                {
                    invstocklist = result.OrderBy(b => b.id)
                                            .Skip((inv_StockQueryParameters.PageNumber - 1) * inv_StockQueryParameters.PageSize)
                                            .Take(inv_StockQueryParameters.PageSize).Select(a => new Inv_StockViewModel
                                            {
                                                dt_crtd = a.dt_crtd,
                                                id = a.id,
                                                prodtype = a.prodtype,
                                                productname = a.productname,
                                                prod_id = a.prod_id,
                                                qty = a.qty,
                                                SKU = a.SKU,
                                                targ_inv_level = a.targ_inv_level,
                                                uom = a.uom
                                            }).ToList();

                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }

            return invstocklist;
        }
    }
}
