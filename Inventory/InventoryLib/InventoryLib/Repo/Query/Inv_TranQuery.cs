using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo.Abstract;
using InventoryLib.Server;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace InventoryLib.Repo.Query
{
    public class Inv_TranQuery : IInv_TranQuery
    {
        InventoryDbContext context;
        ILogger<Inv_TranQuery> logger;
        int resultid = 0;
        public Inv_TranQuery(InventoryDbContext context, ILogger<Inv_TranQuery> logger)
        {
            this.logger = logger;
            this.context = context;

        }
        public Inv_Tran GetInventoryTransaction(int inv_Tranid)
        {
            Inv_Tran invtran = new Inv_Tran();
            try
            {
                var query = context.Inv_Trans.Find(inv_Tranid);
                if (query == null)
                {
                    invtran = null;
                }
                else
                {
                    invtran = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return invtran;
        }

        public List<Inv_TransViewModel> SearchInventoryTransaction(Inv_TransQueryParameters inv_TransQueryParameters)
        {
            List<Inv_TransViewModel> invtranslist = new List<Inv_TransViewModel>();
            try
            {
                var result = from a in context.Inv_Trans
                             join b in context.Inv_Stocks on a.inv_stock_id equals b.id
                             join c in context.Products on b.prod_id equals c.id
                             join e in context.Prod_Types on c.prod_type_id equals e.id into prodtypegroup
                             from f in prodtypegroup
                             where a.status == 1
                             select new
                             {
                                 qty = a.qty,
                                 id = a.id,
                                 inv_stock_id = a.inv_stock_id,
                                 note = a.note,
                                 dir = a.dir,
                                 dt_crtd = a.dt_crtd,
                                 lot_id = a.lot_id,
                                 SKU = b.SKU,
                                 prod_id = b.prod_id,
                                 productname = c.descr,
                                 prodtype = f.descr,
                                 uom = c.uomid

                             };
                if (inv_TransQueryParameters.dir != null)
                {
                    result  = result.Where(a => a.dir == inv_TransQueryParameters.dir); 

                }
                if (inv_TransQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= inv_TransQueryParameters.dtcreatedfrom);

                }
                if (inv_TransQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= inv_TransQueryParameters.dtcreatedto);

                }
                if (inv_TransQueryParameters.prod_id != null)
                {
                    result = result.Where(a => a.prod_id == inv_TransQueryParameters.prod_id);

                }
                if (inv_TransQueryParameters.prod_name != null)
                {
                    result = result.Where(a => a.productname.Contains(inv_TransQueryParameters.prod_name));

                }
                if (inv_TransQueryParameters.lot_id != null)
                {
                    result = result.Where(a => a.lot_id == inv_TransQueryParameters.lot_id);

                }
                if (inv_TransQueryParameters.inv_stock_id != null)
                {
                    result = result.Where(a => a.inv_stock_id == inv_TransQueryParameters.inv_stock_id);

                }
                if (result != null)
                {
                    invtranslist = result.OrderBy(b => b.id)
                                            .Skip((inv_TransQueryParameters.PageNumber - 1) * inv_TransQueryParameters.PageSize)
                                            .Take(inv_TransQueryParameters.PageSize).Select(a => new Inv_TransViewModel
                                            {
                                                dt_crtd = a.dt_crtd,
                                                id = a.id,
                                                prodtype = a.prodtype,
                                                productname = a.productname,
                                                dir = a.dir,    
                                                inv_stock_id = a.inv_stock_id,
                                                lot_id = a.lot_id,  
                                                note = a.note,                                                
                                                qty = a.qty,                                               
                                                uom = a.uom
                                            }).ToList();

                }
            }

            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return invtranslist;
        }
    }
}
