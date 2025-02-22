using InventoryLib.Model;
using InventoryLib.QueryParameters;
using Common.Model;
using InventoryLib.ViewModel;
using Common.Response;

namespace InventoryLib.Core.Abstract
{
    public interface IMeasCore
    {
        CommandResponse AddMeas(MeasAddViewModel manfAddViewModel);
        CommandResponse UpdateMeas(int measid, MeasAddViewModel manfAddViewModel);
        CommandResponse DeleteMeas(int measid);


        QueryResponse<CountModel<Mea>> SearchMeas(MeasQueryParameters measQueryParameters);
        QueryResponse<Mea> GetMea(int measid);
    }

}
