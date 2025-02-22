using Microsoft.Extensions.Logging;
using POSLib.Model;
using POSLib.QueryParameters;
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
    public class UserQuery : IUserQuery
    {
        POSDbContext context;
        ILogger<UserQuery> logger;
        int resultid = 0;
        public UserQuery(POSDbContext context, ILogger<UserQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public User GetUser(Guid userid)
        {
            User user = new User();
            try
            {
                var query = context.Users.Find(userid);
                if (query == null)
                {
                    user = null;
                }
                else
                {
                    user = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return user;
        }

        public List<User> GetUsers(UserQueryParameters userQueryParameters)
        {
            List<User> users = new List<User>();
            try
            {
                var query = context.Users.AsQueryable();
                query = query.Where(a => a.STATUS == 1);
                if (userQueryParameters.roleid != null)
                {
                    query = query.Where(a => a.roleid == userQueryParameters.roleid);   

                }
                if (userQueryParameters.roleid != null)
                {
                    query = query.Where(a => a.roleid == userQueryParameters.roleid);

                }
                if (userQueryParameters.name != null)
                {
                    query = query.Where(a => a.fullname.Contains(userQueryParameters.name));

                }
                if (userQueryParameters.created_from != null)
                {
                    query = query.Where(a => a.DT_CRTD >= userQueryParameters.created_from);

                }
                if (userQueryParameters.created_to != null)
                {
                    query = query.Where(a => a.DT_CRTD <= userQueryParameters.created_to);

                }

                if (query.Count() > 0)
                {
                    users = query.ToList();
                }
       

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return users;
        }
    }
}
