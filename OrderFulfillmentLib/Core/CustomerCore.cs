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
    public class CustomerCore : ICustomerCore
    {
        ICustomerCommand customerCommand;
        ICustomerQuery customerQuery;
        ILogger<CustomerCore> logger;
        public CustomerCore(ICustomerCommand customerCommand, ICustomerQuery customerQuery, ILogger<CustomerCore> logger)
        {
            this.customerCommand = customerCommand;
            this.customerQuery = customerQuery;
            this.logger = logger;
        }
        public CommandResponse AddCustomerCore(CustomerAddViewModel CustomerAddViewModel)
        {
            int result = 0;
            try
            {
                result = customerCommand.AddCustomer(new Customer
                {
                    add_line_1 = CustomerAddViewModel.add_line_1,
                    add_line_2 = CustomerAddViewModel.add_line_2,
                    city = CustomerAddViewModel.city,
                    country = CustomerAddViewModel.country,
                    customerid = Guid.NewGuid(),
                    dob = CustomerAddViewModel.dob,
                    email = CustomerAddViewModel.email,
                    first_name = CustomerAddViewModel.first_name,
                    last_name = CustomerAddViewModel.last_name,
                    phone = CustomerAddViewModel.phone,
                    state = CustomerAddViewModel.state,
                    zipcode = CustomerAddViewModel.zipcode
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddCustomerCore)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse DeleteCustomer(Guid Customerid)
        {
            bool result = false;
            try
            {
                result = customerCommand.DeleteCustomer(Customerid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddCustomerCore)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Customer> GetCustomer(Guid Customerid)
        {
            QueryResponse<Customer> queryResponse = new QueryResponse<Customer>();
            try
            {
                Customer customer = new Customer();
                if (Customerid != null)
                {
                    customer = customerQuery.GetCutomer(Customerid);
                    queryResponse = QueryResponse<Customer>.Load(customer);
                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetCustomer)}");
            }


            return queryResponse;
        }

        public QueryResponse<CountModel<Customer>> GetCustomers(CustomerQueryParameters CustomerQueryParameters)
        {
            QueryResponse<CountModel<Customer>> queryResponse = new QueryResponse<CountModel<Customer>>();
            try
            {

                var list = customerQuery.SearchCustomer(CustomerQueryParameters);
                var plist = PagedList<Customer>.ToPagedIList(list, CustomerQueryParameters.PageNumber, CustomerQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Customer>>.Load(CountModel<Customer>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetCustomers)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchCustomer(Guid Customerid, CustomerPatchViewModel CustomerPatchViewModel)
        {
            int result = 0;
            try
            {
                result = customerCommand.PatchCustomer(Customerid, CustomerPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateCustomer)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse UpdateCustomer(Guid Customerid, CustomerPatchViewModel CustomerPatchViewModel)
        {
            int result = 0;
            try
            {
                result = customerCommand.PatchCustomer(Customerid,CustomerPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateCustomer)}");
            }
            return CommandResponse.Load(result);
        }
    }
}
