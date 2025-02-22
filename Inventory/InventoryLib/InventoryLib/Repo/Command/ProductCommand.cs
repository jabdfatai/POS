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
    public class ProductCommand : IProductCommand
    {
        InventoryDbContext context;
        ILogger<ProductCommand> logger;
        int resultid = 0;
        public ProductCommand(InventoryDbContext context,ILogger<ProductCommand> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public int AddProduct(ProductAddViewModel productAddViewModel)
        {
            try
            {
                context.Products.Add(new Product
                {
                    descr = productAddViewModel.descr,
                    manf_id = productAddViewModel.manf_id,
                    prod_type_id =productAddViewModel.prod_type_id,
                    uomid = productAddViewModel.uomid

                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteProduct(int productid)
        {
            bool deletestatus = false;
            try
            {

                var selprodrec = context.Products.Find(productid);
                selprodrec.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int PatchProduct(int productid, ProductPatchViewModel productPatchViewModel)
        {
            try
            {
                var selproductrec = context.Products.Find(productid);
                if (selproductrec != null)
                {
                    if (productPatchViewModel.manf_id != null)
                    {
                        selproductrec.manf_id = productPatchViewModel.manf_id.Value;
                    }
                    if (productPatchViewModel.uomid != null)
                    {
                        selproductrec.uomid = productPatchViewModel.uomid.Value;
                    }

                    if (productPatchViewModel.prod_type_id != null)
                    {
                        selproductrec.prod_type_id = productPatchViewModel.prod_type_id.Value;
                    }
                    if (productPatchViewModel.descr != null)
                    {
                        selproductrec.descr = productPatchViewModel.descr;
                    }
                  
                    selproductrec.dt_modf = DateTime.UtcNow;
                    resultid = context.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public int UpdateProduct(int productid, ProductAddViewModel productAddViewModel)
        {
            try
            {
                var selproductrec = context.Products.Find(productid);
                if (selproductrec != null)
                {
                    selproductrec.manf_id = productAddViewModel.manf_id;
                    selproductrec.uomid = productAddViewModel.uomid;
                    selproductrec.prod_type_id = productAddViewModel.prod_type_id;
                    selproductrec.descr = productAddViewModel.descr;
                    selproductrec.dt_modf = DateTime.UtcNow;
                    resultid = context.SaveChanges();
                }
           
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }
    }
}
