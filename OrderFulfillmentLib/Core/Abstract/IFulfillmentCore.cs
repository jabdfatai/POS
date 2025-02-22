
using Common.Model;
using Common.Response;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;

namespace OrderFulfillmentLib.Core.Abstract
{
    public interface IFulfillmentCore
    {
        public CommandResponse AddFulfillment(FulfillmentAddViewModel FulfillmentAddViewModel);

        public CommandResponse UpdateFulfillment(int Fulfillmentid, FulfillmentPatchViewModel FulfillmentPatchViewModel);
        public CommandResponse PatchFulfillment(int Fulfillmentid, FulfillmentPatchViewModel FulfillmentPatchViewModel);
        public CommandResponse DeleteFulfillment(int Fulfillmentid);

        public QueryResponse<CountModel<Fulfillment>> GetFulfillments(FulfillmentQueryParameter FulfillmentQueryParameters);

        public QueryResponse<Fulfillment> GetFulfillment(int Fulfillmentid);
    }



}
