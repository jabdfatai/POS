using InventoryLib.Core;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
using Common.Model;
using InventoryLib.ViewModel;
using Common.Response;

namespace InventoryLib.Core.Abstract
{
    public interface  ILotCore
    {
        CommandResponse AddLot(LotAddViewModel lotAddViewModel);
        CommandResponse UpdateLot(int lotid, LotAddViewModel lotAddViewModel);
        CommandResponse PatchLot(int lotid, LotPatchViewModel lotPatchViewModel);
        CommandResponse DeleteLot(int lotid);

        QueryResponse<CountModel<Lot>> SearchLot(LotQueryParameters lotQueryParameters);
        QueryResponse<Lot> GetLot(int lotid);
    }
   
}
