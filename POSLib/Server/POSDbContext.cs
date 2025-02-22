using Microsoft.EntityFrameworkCore;
using POSLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Server
{
    public class POSDbContext:DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options) : base(options)
        {
            
        }
 
        public DbSet<Bar_Config> Bar_Configs { get; set; }
        public DbSet<PosScanEntry> PosScanEntries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
    


    }
}
