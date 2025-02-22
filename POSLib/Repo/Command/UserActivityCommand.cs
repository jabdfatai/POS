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
    public class UserActivityCommand : IUserActivityCommand
    {
        POSDbContext context;
        ILogger<UserActivityCommand> logger;
        int resultid = 0;
        public UserActivityCommand(POSDbContext context,ILogger<UserActivityCommand> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public int AddUserActivity(UserActivityAddViewModel userActivityAddViewModel)
        {
            try
            {
                context.UserActivities.Add(new UserActivity
                {
                    action = userActivityAddViewModel.action,
                    entity_affected = userActivityAddViewModel.entity_affected,
                    ipaddress = userActivityAddViewModel.ipaddress,
                    rec_affected = userActivityAddViewModel.rec_affected,   
                    userid = userActivityAddViewModel.userid

                });
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
