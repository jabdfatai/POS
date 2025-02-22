using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Abstract
{
   public interface IManfCommand
    {
        int AddManf(ManfAddViewModel manfAddViewModel);
        int UpdateManf(int manfid, ManfAddViewModel manfAddViewModel);
        bool DeleteManf(int manfid);
    }
    public interface IManfQuery
    {
        List<Manf> SearchManf(ManfQueryParameters manfQueryParameters);
        Manf GetManf(int manfid);
    }
}
