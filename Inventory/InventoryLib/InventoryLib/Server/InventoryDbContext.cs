using InventoryLib.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Server
{

    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Code_Tab> Code_Tabs { get; set; }
        public DbSet<Inv_Stock> Inv_Stocks { get; set; }
        public DbSet<Inv_Tran> Inv_Trans { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Manf> Manfs { get; set; }
        public DbSet<Mea> Meas { get; set; }
        public DbSet<Prod_Cat> Prod_Cats { get; set; }
        public DbSet<Prod_Type> Prod_Types { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Pur_Order> Pur_Orders { get; set; }


        public DbSet<Pur_Ord_Dtl> Pur_Ord_Dtls { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Vend_Prod> Vend_Prods { get; set; }
 
    }
}
