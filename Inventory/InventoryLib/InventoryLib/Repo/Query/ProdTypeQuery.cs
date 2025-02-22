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
    public class ProdTypeQuery : IProdTypeQuery
    {
        InventoryDbContext context;
        ILogger<ProdTypeQuery> logger;
        int resultid = 0;
        public ProdTypeQuery(InventoryDbContext context,ILogger<ProdTypeQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }

        public Prod_Type GetProdType(int prodtypeid)
        {
            Prod_Type prodtype  = new Prod_Type();
            try
            {
                var query = context.Prod_Types.Find(prodtypeid);
                if (query == null)
                {
                    prodtype = null;
                }
                else
                {
                    prodtype = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return prodtype;
        }

        public List<Prod_Type> SearchProdType(ProductTypeQueryParameters productTypeQueryParameters)
        {
            List<Prod_Type> prodtypelist = new List<Prod_Type>();
            try
            {
                var result = context.Prod_Types.Where(a => a.status == 1);
                if (productTypeQueryParameters.descr != null)
                {
                  result = result.Where(a => a.descr.Contains(productTypeQueryParameters.descr));
                }

                if (productTypeQueryParameters.prod_cat_id != null)
                {
                    result = result.Where(a => a.prod_cat_id == productTypeQueryParameters.prod_cat_id);
                }

                if (productTypeQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= productTypeQueryParameters.dtcreatedfrom);
                }
                if (productTypeQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= productTypeQueryParameters.dtcreatedto);
                }
                if (result.Count() > 0)
                {
                    prodtypelist = result.OrderBy(b => b.id)
                                            .Skip((productTypeQueryParameters.PageNumber - 1) * productTypeQueryParameters.PageSize)
                                            .Take(productTypeQueryParameters.PageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return prodtypelist;
        }
    }
}
