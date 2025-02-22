using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Repo.Abstract
{
    public interface IProductTrackerCommand
    {
        int AddProductTracker(ProductTracker productTracker);
        int PatchProductTracker(int id, ProductTrackerPatchViewModel productTrackerPatchViewModel);
        bool DeleteProductTracker(int id);
    }

    public interface IProductTrackerQuery
    {
        List<ProductTracker> SearchProductTracker(ProductTrackerQueryParameter productTrackerQueryParameter);

        ProductTracker GetProductTracker(int id);
    }
}
