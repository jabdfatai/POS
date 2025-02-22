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
    public interface IFulfillmentCommand
    {
        int AddFulfillment(Fulfillment fulfillment);
        int PatchFulfillment(int id, FulfillmentPatchViewModel fulfillmentPatchViewModel);
        bool DeleteFulfillment(int id);
    }
    public interface IFulfillmentQuery
    {
        List<Fulfillment> SearchFulfillment(FulfillmentQueryParameter fulfillmentQueryParameter);
        Fulfillment GetFulfillment(int id);
    }
}
