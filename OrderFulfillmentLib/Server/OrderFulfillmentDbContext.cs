
using Microsoft.EntityFrameworkCore;
using OrderFulfillmentLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Server
{
 
        public class OrderFulfillmentDbContext : DbContext
        {
            public OrderFulfillmentDbContext(DbContextOptions<OrderFulfillmentDbContext> options) : base(options)
            {

            }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Fulfillment>  fulfillments { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<OrderDelivery> orderDeliveries { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<PayProvider> payProviders { get; set; }
        public DbSet<ProductTracker> productTrackers { get; set; }
    }
}
