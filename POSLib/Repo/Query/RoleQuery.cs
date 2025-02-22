
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

namespace POSLib.Repo.Query
{
    public class RoleQuery : IRoleQuery
    {
        POSDbContext context;
        ILogger<RoleQuery> logger;
        int resultid = 0;
        public RoleQuery(POSDbContext context,ILogger<RoleQuery> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Role GetRole(int roleid)
        {
            Role role = new Role();
            try
            {
                var query = context.Roles.Find(roleid);
                if (query == null)
                {
                    role = null;
                }
                else
                {
                    role = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return role;
        }

        public List<Role> GetRoles(string rolename)
        {
            List<Role> roles = new List<Role>();
            try
            {
                var query = context.Roles.AsQueryable();
                query = query.Where(a => a.STATUS == 1);
                if (!string.IsNullOrEmpty(rolename))
                {
                    query = query.Where(a => a.descr.Contains(rolename));
                }
                
                if (query != null)
                {
                    roles = query.ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return roles;
        }
       



    }
}
