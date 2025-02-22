using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Abstract
{
    public interface IMeasCommand
    {
        int AddMeas(MeasAddViewModel manfAddViewModel);
        int UpdateMeas(int measid, MeasAddViewModel manfAddViewModel);
        bool DeleteMeas(int measid);
    }
    public interface IMeasQuery
    {
        List<Mea> SearchMeas(MeasQueryParameters measQueryParameters);
        Mea GetMeas(int measid);
    }
}
