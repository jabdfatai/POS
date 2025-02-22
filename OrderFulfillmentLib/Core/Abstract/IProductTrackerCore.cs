
using Common.Model;
using Common.Response;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;

namespace OrderFulfillmentLib.Core.Abstract
{
    public interface IProductTrackerCore
    {
        public CommandResponse AddProductTracker(ProductTrackerAddViewModel ProductTrackerAddViewModel);

        public CommandResponse UpdateProductTracker(int ProductTrackerid, ProductTrackerPatchViewModel ProductTrackerPatchViewModel);
        public CommandResponse PatchProductTracker(int ProductTrackerid, ProductTrackerPatchViewModel ProductTrackerPatchViewModel);
        public CommandResponse DeleteProductTracker(int ProductTrackerid);

        public QueryResponse<CountModel<ProductTracker>> GetProductTrackers(ProductTrackerQueryParameter ProductTrackerQueryParameters);

        public QueryResponse<ProductTracker> GetProductTracker(int ProductTrackerid);
    }



}
