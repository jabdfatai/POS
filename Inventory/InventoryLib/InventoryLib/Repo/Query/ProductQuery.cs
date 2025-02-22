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
    public class ProductQuery : IProductQuery
    {
        InventoryDbContext context;
        ILogger<ProductQuery> logger;
        int resultid = 0;
        public ProductQuery(InventoryDbContext context,ILogger<ProductQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public Product GetProduct(int productid)
        {
            Product product = new Product();
            try
            {
                var query = context.Products.Find(productid);
                if (query == null)
                {
                    product = null;
                }
                else
                {
                    product = query;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return product;
        }

        public List<Product> SearchProduct(ProductQueryParameters productQueryParameters)
        {
            List<Product> prodlist = new List<Product>();
            try
            {
                var result = context.Products.Where(a => a.status == 1);

                if (productQueryParameters.descr != null)
                {
                    result = result.Where(a => a.descr.Contains(productQueryParameters.descr));
                }
                if (productQueryParameters.uomid != null)
                {
                    result = result.Where(a => a.uomid == productQueryParameters.uomid);
                }
                if (productQueryParameters.prod_type_id != null)
                {
                    result = result.Where(a => a.prod_type_id == productQueryParameters.prod_type_id);
                }
                if (productQueryParameters.manf_id != null)
                {
                    result = result.Where(a => a.manf_id == productQueryParameters.manf_id);
                }
                if (productQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= productQueryParameters.dtcreatedfrom);
                }
                if (productQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= productQueryParameters.dtcreatedto);
                }
                if (result.Count() > 0)
                {
                    prodlist = result.OrderBy(b => b.id)
                                            .Skip((productQueryParameters.PageNumber - 1) * productQueryParameters.PageSize)
                                            .Take(productQueryParameters.PageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return prodlist;
        }
    }
}
