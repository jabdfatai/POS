
using Common.Model;
using Common.Response;
using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Core.Abstract;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.Repo.Command;
using OrderFulfillmentLib.Repo.Query;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Core
{
    public class FulfillmentCore : IFulfillmentCore
    {
        IFulfillmentCommand fulfillmentCommand;
        IFulfillmentQuery fulfillmentQuery;
        ILogger<FulfillmentCore> logger;
        public FulfillmentCore(IFulfillmentCommand fulfillmentCommand,IFulfillmentQuery fulfillmentQuery,ILogger<FulfillmentCore> logger)
        {
            this.fulfillmentQuery = fulfillmentQuery;
            this.logger = logger;
            this.fulfillmentCommand = fulfillmentCommand;

        }
        public CommandResponse AddFulfillment(FulfillmentAddViewModel FulfillmentAddViewModel)
        {
            int result = 0;
            try
            {
                result = fulfillmentCommand.AddFulfillment(new Fulfillment
                {
                  fulfillment_status = FulfillmentAddViewModel.fulfillment_status,
                  order_id = FulfillmentAddViewModel.order_id,
                  paymentid = FulfillmentAddViewModel.paymentid,
                  remarks = FulfillmentAddViewModel.remarks
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddFulfillment)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse DeleteFulfillment(int Fulfillmentid)
        {
            bool result = false;
            try
            {
                result = fulfillmentCommand.DeleteFulfillment(Fulfillmentid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteFulfillment)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Fulfillment> GetFulfillment(int Fulfillmentid)
        {
            QueryResponse<Fulfillment> queryResponse = new QueryResponse<Fulfillment>();
            try
            {
               Fulfillment fulfillment = new Fulfillment();
                if (Fulfillmentid != null)
                {
                    fulfillment = fulfillmentQuery.GetFulfillment(Fulfillmentid);
                    queryResponse = QueryResponse<Fulfillment>.Load(fulfillment);
                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetFulfillment)}");
            }


            return queryResponse;
        }

        public QueryResponse<CountModel<Fulfillment>> GetFulfillments(FulfillmentQueryParameter FulfillmentQueryParameters)
        {
            QueryResponse<CountModel<Fulfillment>> queryResponse = new QueryResponse<CountModel<Fulfillment>>();
            try
            {

                var list = fulfillmentQuery.SearchFulfillment(FulfillmentQueryParameters);
                var plist = PagedList<Fulfillment>.ToPagedIList(list, FulfillmentQueryParameters.PageNumber, FulfillmentQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Fulfillment>>.Load(CountModel<Fulfillment>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetFulfillments)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchFulfillment(int Fulfillmentid, FulfillmentPatchViewModel FulfillmentPatchViewModel)
        {
            int result = 0;
            try
            {
                result = fulfillmentCommand.PatchFulfillment(Fulfillmentid, FulfillmentPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchFulfillment)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse UpdateFulfillment(int Fulfillmentid, FulfillmentPatchViewModel FulfillmentPatchViewModel)
        {
            int result = 0;
            try
            {
                result = fulfillmentCommand.PatchFulfillment(Fulfillmentid, FulfillmentPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchFulfillment)}");
            }
            return CommandResponse.Load(result);
        }
    }
}
