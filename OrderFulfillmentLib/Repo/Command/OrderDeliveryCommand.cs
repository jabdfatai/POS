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
    public class OrderDeliveryCommand : IOrderDeliveryCommand
    {
        OrderFulfillmentDbContext context;
        ILogger<OrderDeliveryCommand> logger;
        int resultid = 0;

        public OrderDeliveryCommand(OrderFulfillmentDbContext context, ILogger<OrderDeliveryCommand> logger)
        {
            this.context = context;
            this.logger = logger;

        }

        public int AddOrderDelivery(OrderDelivery orderDelivery)
        {
            try
            {
                context.orderDeliveries.Add(orderDelivery);
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteOrderDelivery(int id)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.orderDeliveries.Find(id);
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

        public int PatchOrderDelivery(int id, OrderDeliveryPatchViewModel orderDeliveryPatchViewModel)
        {
            try
            {
                var selrec = context.orderDeliveries.Find(id);
                selrec.add_line1 = orderDeliveryPatchViewModel.add_line1 == null ? selrec.add_line1 : orderDeliveryPatchViewModel.add_line1;
                selrec.add_line2 = orderDeliveryPatchViewModel.add_line2 == null ? selrec.add_line2 : orderDeliveryPatchViewModel.add_line2;
                selrec.state = orderDeliveryPatchViewModel.state == null ? selrec.state : orderDeliveryPatchViewModel.state;
                selrec.country = orderDeliveryPatchViewModel.country == null ? selrec.country : orderDeliveryPatchViewModel.country;
                selrec.zipcode = orderDeliveryPatchViewModel.zipcode == null ? selrec.zipcode : orderDeliveryPatchViewModel.zipcode;
                selrec.city = orderDeliveryPatchViewModel.city == null ? selrec.city : orderDeliveryPatchViewModel.city;
                selrec.contact_email = orderDeliveryPatchViewModel.contact_email == null ? selrec.contact_email : orderDeliveryPatchViewModel.contact_email;
                selrec.contact_name = orderDeliveryPatchViewModel.contact_name == null ? selrec.contact_name : orderDeliveryPatchViewModel.contact_name;
                selrec.contact_phone = orderDeliveryPatchViewModel.contact_phone == null ? selrec.contact_phone : orderDeliveryPatchViewModel.contact_phone;
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
