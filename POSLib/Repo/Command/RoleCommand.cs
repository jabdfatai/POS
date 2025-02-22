using Microsoft.Extensions.Logging;
using POSLib.Model;
using POSLib.Repo.Abstract;
using POSLib.Server;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Repo.Command
{
    public class RoleCommand:IRoleCommand
    {
        POSDbContext context;
        ILogger<RoleCommand> logger;
        int resultid = 0;
        public RoleCommand(POSDbContext context,ILogger<RoleCommand> logger)
        {
               this.context = context;
            this.logger = logger;
        }

        public int AddRole(RoleAddViewModel roleAddViewModel)
        {
            try
            {
                context.Roles.Add(new Role
                {
                  descr = roleAddViewModel.description

                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteRole(int roleid)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.Roles.Find(roleid);
                selrec.STATUS = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }
    }
}
