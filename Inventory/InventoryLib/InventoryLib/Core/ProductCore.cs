using Common.Model;
using Common.Response;
using InventoryLib.Core.Abstract;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo;
using InventoryLib.Repo.Abstract;
using InventoryLib.Repo.Command;
using InventoryLib.Repo.Query;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Core
{
    public class ProductCore : IProductCore
    {
        IProductCommand ProductCommand;
        IProductQuery ProductQuery;
        ILogger<ProductCore> logger;
        public ProductCore(IProductCommand ProductCommand,IProductQuery ProductQuery,ILogger<ProductCore> logger)
        {
            this.ProductCommand = ProductCommand;
            this.ProductQuery = ProductQuery;
            this.logger = logger;
        }

        public CommandResponse AddProduct(ProductAddViewModel ProductAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = ProductCommand.AddProduct(ProductAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddProduct)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteProduct(int Productid)
        {
            bool result = false;
            try
            {
                result = ProductCommand.DeleteProduct(Productid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteProduct)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Product> GetProduct(int Productid)
        {
            QueryResponse<Product> queryResponse = new QueryResponse<Product>();
            try
            {
                Product Product = new Product();

                Product = ProductQuery.GetProduct(Productid);

                if (Product != null)
                {
                    queryResponse = QueryResponse<Product>.Load(Product);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetProduct)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchProduct(int productid, ProductPatchViewModel productPatchViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = ProductCommand.PatchProduct(productid, productPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddProduct)}");
            }
            return CommandResponse.Load(resultid);
        }

        public QueryResponse<CountModel<Product>> SearchProduct(ProductQueryParameters ProductQueryParameters)
        {
            QueryResponse<CountModel<Product>> queryResponse = new QueryResponse<CountModel<Product>>();
            try
            {

                var list = ProductQuery.SearchProduct(ProductQueryParameters);
                var plist = PagedList<Product>.ToPagedIList(list, ProductQueryParameters.PageNumber, ProductQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Product>>.Load(CountModel<Product>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(SearchProduct)}");
            }
            return queryResponse;
        }

        public CommandResponse UpdateProduct(int Productid, ProductAddViewModel ProductAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = ProductCommand.UpdateProduct(Productid,ProductAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateProduct)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
