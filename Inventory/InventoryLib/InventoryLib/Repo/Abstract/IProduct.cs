using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace InventoryLib.Repo
{
    public interface IProductCommand
    {
        int AddProduct(ProductAddViewModel productAddViewModel);
        int UpdateProduct(int productid, ProductAddViewModel productAddViewModel);
        int PatchProduct(int productid, ProductPatchViewModel productAddViewModel);
        bool DeleteProduct(int productid);
    }
    public interface IProductQuery
    {
        List<Product> SearchProduct(ProductQueryParameters productQueryParameters);
        Product GetProduct(int productid);
    }
}
