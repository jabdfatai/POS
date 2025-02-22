using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Abstract
{
    public interface IProdCatCommand
    {
        int AddProdCat(Prod_CatAddViewModel prod_CatAddViewModel);
        int UpdateProdCat(int prodcatid, Prod_CatAddViewModel prod_CatAddViewModel);
        bool DeleteProdCat(int prodcatid);
    }
    public interface IProdCatQuery
    {
        List<Prod_Cat> SearchProdCategory(Prod_CatQueryParameters prod_CatQueryParameters);
        Prod_Cat GetProdCat(int prodcatid);
    }
}
