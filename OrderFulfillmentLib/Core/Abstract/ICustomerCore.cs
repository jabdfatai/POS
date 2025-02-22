
using Common.Model;
using Common.Response;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Core.Abstract
{
    public interface ICustomerCore
    {
        public CommandResponse AddCustomerCore(CustomerAddViewModel CustomerAddViewModel);

        public CommandResponse UpdateCustomer(Guid Customerid, CustomerPatchViewModel CustomerPatchViewModel);
        public CommandResponse PatchCustomer(Guid Customerid, CustomerPatchViewModel CustomerPatchViewModel);
        public CommandResponse DeleteCustomer(Guid Customerid);

        public QueryResponse<CountModel<Customer>> GetCustomers(CustomerQueryParameters CustomerQueryParameters);

        public QueryResponse<Customer> GetCustomer(Guid Customerid);
    }



}
