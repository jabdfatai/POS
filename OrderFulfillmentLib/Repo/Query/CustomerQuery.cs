
using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.Repo.Command;
using OrderFulfillmentLib.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Repo.Query
{
    public class CustomerQuery : ICustomerQuery
    {
        OrderFulfillmentDbContext context;
        ILogger<CustomerQuery> logger;
        int resultid = 0;
        public CustomerQuery(OrderFulfillmentDbContext context,
        ILogger<CustomerQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public Customer GetCutomer(Guid customerid)
        {
            Customer customer = new Customer();
            try
            {
                var query = context.customers.Find(customerid);
                if (query == null)
                {
                    customer = null;
                }
                else
                {
                    customer = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return customer;
        }

        public List<Customer> SearchCustomer(CustomerQueryParameters customerQueryParameters)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                var query = context.customers.AsQueryable();
                query = query.Where(a => a.status == 1);
                if (customerQueryParameters.country != null)
                {
                    query = query.Where(a => a.country == customerQueryParameters.country);

                }
                if (customerQueryParameters.state != null)
                {
                    query = query.Where(a => a.state == customerQueryParameters.state);

                }
                if (customerQueryParameters.phone != null)
                {
                    query = query.Where(a => a.phone.Contains(customerQueryParameters.phone));

                }
                if (customerQueryParameters.name != null)
                {
                    query = query.Where(a => (a.first_name + a.last_name).Contains(customerQueryParameters.name));

                }

                if (customerQueryParameters.dtcreatedfrom != null)
                {
                    query = query.Where(a => a.dt_crtd >= customerQueryParameters.dtcreatedfrom);

                }
                if (customerQueryParameters.dtcreatedto != null)
                {
                    query = query.Where(a => a.dt_crtd <= customerQueryParameters.dtcreatedto);

                }

                if (query.Count() > 0)
                {
                    customers = query.OrderBy(b => b.id)
                    .Skip((customerQueryParameters.PageNumber - 1) * customerQueryParameters.PageSize)
                                            .Take(customerQueryParameters.PageSize).Select(a => new Customer
                                            {
                                                dt_crtd = a.dt_crtd,
                                                id = a.id,
                                                add_line_1 = a.add_line_1,
                                                add_line_2 = a.add_line_2,
                                                city = a.city,
                                                country = a.country,
                                                customerid = a.customerid,
                                                dob = a.dob,
                                                dt_modf = a.dt_modf,
                                                email = a.email,
                                                first_name = a.first_name,
                                                last_name = a.last_name,
                                                phone = a.phone,
                                                state = a.state,
                                                zipcode = a.zipcode
                                            }).ToList();

                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return customers;
        }
    }
}
