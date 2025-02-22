using InventoryLib.Model;
using InventoryLib.QueryParameters;
using Common.Model;
using InventoryLib.ViewModel;
using Common.Response;

namespace InventoryLib.Core.Abstract
{
    public interface IProductCore
    {
        CommandResponse AddProduct(ProductAddViewModel productAddViewModel);
        CommandResponse UpdateProduct(int productid, ProductAddViewModel productAddViewModel);
        CommandResponse PatchProduct(int productid, ProductPatchViewModel productAddViewModel);
        CommandResponse DeleteProduct(int productid);
   
        QueryResponse<CountModel<Product>> SearchProduct(ProductQueryParameters productQueryParameters);
        QueryResponse<Product> GetProduct(int productid);
    }
}
