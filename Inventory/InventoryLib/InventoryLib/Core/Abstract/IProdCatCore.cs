using InventoryLib.Model;
using InventoryLib.QueryParameters;
using Common.Model;
using InventoryLib.ViewModel;
using Common.Response;

namespace InventoryLib.Core.Abstract
{
    public interface IProdCatCore
    {
        CommandResponse AddProdCat(Prod_CatAddViewModel prod_CatAddViewModel);
        CommandResponse UpdateProdCat(int prodcatid, Prod_CatAddViewModel prod_CatAddViewModel);
        CommandResponse DeleteProdCat(int prodcatid);
  
        QueryResponse<CountModel<Prod_Cat>> SearchProdCat(Prod_CatQueryParameters prod_CatQueryParameters);
        QueryResponse<Prod_Cat> GetProdCat(int prodcatid);
    }

}
