using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo
{
    public interface IProdTypeCommand
    {
        int AddProdType(Prod_TypeAddViewModel prod_TypeAddViewModel);
        int UpdateProdType(int prodtypeid, Prod_TypeAddViewModel prod_TypeAddViewModel);
        bool DeleteProdType(int prodtypeid);
    }
    public interface IProdTypeQuery
    {
        List<Prod_Type> SearchProdType(ProductTypeQueryParameters productTypeQueryParameters);
        Prod_Type GetProdType(int prodtypeid);
    }
}
