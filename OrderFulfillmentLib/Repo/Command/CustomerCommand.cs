using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.Server;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Repo.Command
{

    public class CustomerCommand : ICustomerCommand
    {
        OrderFulfillmentDbContext context;
        ILogger<CustomerCommand> logger;
        int resultid = 0;
        public CustomerCommand(OrderFulfillmentDbContext context,
        ILogger<CustomerCommand> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public int AddCustomer(Customer customer)
        {
            try
            {
                context.customers.Add(customer);
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteCustomer(Guid customerid)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.customers.Find(customerid);
                selrec.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int PatchCustomer(Guid customerid, CustomerPatchViewModel customerPatchViewModel)
        {
            try
            {
                var selrec = context.customers.Find(customerid);
                selrec.email = string.IsNullOrEmpty(customerPatchViewModel.email) ? selrec.email : customerPatchViewModel.email;
                selrec.phone = string.IsNullOrEmpty(customerPatchViewModel.phone) ? selrec.phone : customerPatchViewModel.phone;
                selrec.zipcode = customerPatchViewModel.zipcode == null ? selrec.zipcode : customerPatchViewModel.zipcode;
                selrec.dob = customerPatchViewModel.dob == null ? selrec.dob : customerPatchViewModel.dob.Value;
                selrec.add_line_1 = string.IsNullOrEmpty(customerPatchViewModel.add_line_1) ? selrec.add_line_1 : customerPatchViewModel.add_line_1;
                selrec.add_line_2 = string.IsNullOrEmpty(customerPatchViewModel.add_line_2) ? selrec.add_line_2 : customerPatchViewModel.add_line_2;
                selrec.city = string.IsNullOrEmpty(customerPatchViewModel.city) ? selrec.city : customerPatchViewModel.city;
                selrec.country = string.IsNullOrEmpty(customerPatchViewModel.country) ? selrec.country : customerPatchViewModel.country;
                selrec.state = string.IsNullOrEmpty(customerPatchViewModel.state) ? selrec.state : customerPatchViewModel.state;
                selrec.first_name = string.IsNullOrEmpty(customerPatchViewModel.first_name) ? selrec.first_name : customerPatchViewModel.first_name;
                selrec.last_name = string.IsNullOrEmpty(customerPatchViewModel.last_name) ? selrec.last_name : customerPatchViewModel.last_name;
                selrec.dt_modf = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }
    }
}
