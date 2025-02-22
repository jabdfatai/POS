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
    public class ProdCatQuery : IProdCatQuery
    {
        InventoryDbContext context;
        ILogger<ProdCatQuery> logger;
        int resultid = 0;
        public ProdCatQuery(InventoryDbContext context,ILogger<ProdCatQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }

        public Prod_Cat GetProdCat(int prodcatid)
        {
            Prod_Cat prod_Cat  = new Prod_Cat();
            try
            {
                var query = context.Prod_Cats.Find(prodcatid);
                if (query == null)
                {
                    prod_Cat = null;
                }
                else
                {
                    prod_Cat = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return prod_Cat;
        }

        List<Prod_Cat> IProdCatQuery.SearchProdCategory(Prod_CatQueryParameters prod_CatQueryParameters)
        {
            List<Prod_Cat> prodcatlist = new List<Prod_Cat>();
            try
            {
                var result = context.Prod_Cats.Where(a => a.status == 1);
                if (prod_CatQueryParameters.descr != null)
                {
                  result = result.Where(a => a.descr.Contains(prod_CatQueryParameters.descr));
                }
                if (prod_CatQueryParameters.prod_form != null)
                {
                    result = result.Where(a => a.descr.Contains(prod_CatQueryParameters.prod_form));
                }
                if (prod_CatQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= prod_CatQueryParameters.dtcreatedfrom);
                }
                if (prod_CatQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= prod_CatQueryParameters.dtcreatedto);
                }
                if (result.Count() > 0)
                {
                    prodcatlist = result.OrderBy(b => b.id)
                                            .Skip((prod_CatQueryParameters.PageNumber - 1) * prod_CatQueryParameters.PageSize)
                                            .Take(prod_CatQueryParameters.PageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return prodcatlist;
        }

    }
}
