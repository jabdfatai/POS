using InventoryLib.Model;
using InventoryLib.QueryParameters;
using Common.Model;
using InventoryLib.ViewModel;
using Common.Response;

namespace InventoryLib.Core.Abstract
{
    public interface IProdTypeCore
    {
        CommandResponse AddProdType(Prod_TypeAddViewModel prod_TypeAddViewModel);
        CommandResponse UpdateProdType(int prodtypeid, Prod_TypeAddViewModel prod_TypeAddViewModel);
        CommandResponse DeleteProdType(int prodtypeid);  
        QueryResponse<CountModel<Prod_Type>> SearchProdType(ProductTypeQueryParameters productTypeQueryParameters);
        QueryResponse<Prod_Type> GetProdType(int prodtypeid);
    }

}
