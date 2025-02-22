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
    public interface ICustomerCommand
    {
        int AddCustomer(Customer customer);
        int PatchCustomer(Guid customerid, CustomerPatchViewModel customerPatchViewModel);
        bool DeleteCustomer(Guid customerid);
    }
    public interface ICustomerQuery
    {
        List<Customer> SearchCustomer(CustomerQueryParameters customerQueryParameters);
        Customer GetCutomer(Guid customerid);
    }
}
