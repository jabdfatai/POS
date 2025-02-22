using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Abstract
{
    public interface IlotCommand
    {
        int AddLot(LotAddViewModel lotAddViewModel);
        int UpdateLot(int lotid, LotAddViewModel lotAddViewModel);
        int PatchLot(int lotid, LotPatchViewModel lotPatchViewModel);
        bool DeleteLot(int lotid);
    }
    public interface IlotQuery
    {
        List<Lot> SearchLot(LotQueryParameters lotQueryParameters);
        Lot GetLot(int lotid);
    }
}
