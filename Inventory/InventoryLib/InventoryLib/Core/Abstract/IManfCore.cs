using InventoryLib.Model;
using InventoryLib.QueryParameters;
using Common.Model;
using InventoryLib.ViewModel;
using Common.Response;

namespace InventoryLib.Core.Abstract
{
    public interface IManfCore
    {
        CommandResponse AddManf(ManfAddViewModel manfAddViewModel);
        CommandResponse UpdateManf(int manfid, ManfAddViewModel manfAddViewModel);
        CommandResponse DeleteManf(int manfid);
        QueryResponse<CountModel<Manf>> SearchManf(ManfQueryParameters manfQueryParameters);
        QueryResponse<Manf> GetManf(int manfid);
    }

}
