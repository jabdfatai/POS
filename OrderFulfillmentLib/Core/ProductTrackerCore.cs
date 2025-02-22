
using Common.Model;
using Common.Response;
using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Core.Abstract;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Core
{
    public class ProductTrackerCore : IProductTrackerCore
    {
        IProductTrackerCommand ProductTrackerCommand;
        IProductTrackerQuery ProductTrackerQuery;
        ILogger<ProductTrackerCore> logger;
        public ProductTrackerCore(IProductTrackerCommand ProductTrackerCommand, IProductTrackerQuery ProductTrackerQuery, ILogger<ProductTrackerCore> logger)
        {
            this.ProductTrackerQuery = ProductTrackerQuery;
            this.logger = logger;
            this.ProductTrackerCommand = ProductTrackerCommand;

        }
        public CommandResponse AddProductTracker(ProductTrackerAddViewModel ProductTrackerAddViewModel)
        {
            int result = 0;
            try
            {
                result = ProductTrackerCommand.AddProductTracker(new ProductTracker
                {
                  comment = ProductTrackerAddViewModel.comment,
                  order_id = ProductTrackerAddViewModel.order_id,
                  order_loc = ProductTrackerAddViewModel.order_loc,
                  order_status = ProductTrackerAddViewModel.order_status
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddProductTracker)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse DeleteProductTracker(int ProductTrackerid)
        {
            bool result = false;
            try
            {
                result = ProductTrackerCommand.DeleteProductTracker(ProductTrackerid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteProductTracker)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<ProductTracker> GetProductTracker(int ProductTrackerid)
        {
            QueryResponse<ProductTracker> queryResponse = new QueryResponse<ProductTracker>();
            try
            {
                ProductTracker ProductTracker = new ProductTracker();
                if (ProductTrackerid != null)
                {
                    ProductTracker = ProductTrackerQuery.GetProductTracker(ProductTrackerid);
                    queryResponse = QueryResponse<ProductTracker>.Load(ProductTracker);
                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetProductTracker)}");
            }


            return queryResponse;
        }

        public QueryResponse<CountModel<ProductTracker>> GetProductTrackers(ProductTrackerQueryParameter ProductTrackerQueryParameters)
        {
            QueryResponse<CountModel<ProductTracker>> queryResponse = new QueryResponse<CountModel<ProductTracker>>();
            try
            {

                var list = ProductTrackerQuery.SearchProductTracker(ProductTrackerQueryParameters);
                var plist = PagedList<ProductTracker>.ToPagedIList(list, ProductTrackerQueryParameters.PageNumber, ProductTrackerQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<ProductTracker>>.Load(CountModel<ProductTracker>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetProductTrackers)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchProductTracker(int ProductTrackerid, ProductTrackerPatchViewModel ProductTrackerPatchViewModel)
        {
            int result = 0;
            try
            {
                result = ProductTrackerCommand.PatchProductTracker(ProductTrackerid, ProductTrackerPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchProductTracker)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse UpdateProductTracker(int ProductTrackerid, ProductTrackerPatchViewModel ProductTrackerPatchViewModel)
        {
            int result = 0;
            try
            {
                result = ProductTrackerCommand.PatchProductTracker(ProductTrackerid, ProductTrackerPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchProductTracker)}");
            }
            return CommandResponse.Load(result);
        }
    }
}
