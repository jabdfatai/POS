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
    public class UserActivityQuery : IUserActivityQuery
    {
        POSDbContext context;
        ILogger<UserActivityQuery> logger;
        int resultid = 0;
        public UserActivityQuery(POSDbContext context,ILogger<UserActivityQuery> logger)
        {
            this.context = context;

            this.logger = logger;
        }
        public List<UserActivity> GetUserActivities(UserActivityQueryParameters userActivityQueryParameters)
        {
            var actlist = new List<UserActivity>();
            try
            {
                var query = context.UserActivities.AsQueryable();
                query = query.Where(a => a.STATUS == 1);
                if (userActivityQueryParameters.ipaddress != null)
                {
                    query = query.Where(a => a.ipaddress == userActivityQueryParameters.ipaddress);
                }
                if (userActivityQueryParameters.userid != null)
                {
                    query = query.Where(a => a.userid == userActivityQueryParameters.userid);
                }
                if (userActivityQueryParameters.rec_affected != null)
                {
                    query = query.Where(a => a.rec_affected == userActivityQueryParameters.rec_affected);
                }
                if (userActivityQueryParameters.entity_affected != null)
                {
                    query = query.Where(a => a.entity_affected == userActivityQueryParameters.entity_affected);
                }
                if (userActivityQueryParameters.action != null)
                {
                    query = query.Where(a => a.action == userActivityQueryParameters.action);
                }
                if (userActivityQueryParameters.created_from != null)
                {
                    query = query.Where(a => a.DT_CRTD >= userActivityQueryParameters.created_from);
                }
                if (userActivityQueryParameters.created_to != null)
                {
                    query = query.Where(a => a.DT_CRTD <= userActivityQueryParameters.created_to);
                }
                if (query.Count() > 0)
                {
                    actlist = query.ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return actlist;
           
        }
    }
}
