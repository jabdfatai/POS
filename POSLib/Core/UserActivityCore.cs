using Common.Model;
using Common.Response;
using Microsoft.Extensions.Logging;
using POSLib.Core.Abstract;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.Repo.Abstract;
using POSLib.Repo.Command;
using POSLib.Repo.Query;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Core
{
    public class UserActivityCore : IUserActivityCore
    {
        IUserActivityCommand userActivityCommand;
        IUserActivityQuery userActivityQuery;
        ILogger<UserActivityCore> logger;
        public UserActivityCore(IUserActivityCommand userActivityCommand,IUserActivityQuery userActivityQuery,
        ILogger<UserActivityCore> logger)
        {
            this.userActivityCommand = userActivityCommand;
            this.userActivityQuery = userActivityQuery;
            this.logger = logger;

        }
        public CommandResponse AddUserActivity(UserActivityAddViewModel userActivityAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = userActivityCommand.AddUserActivity(userActivityAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddUserActivity)}");
            }
            return CommandResponse.Load(resultid);
        }

        public QueryResponse<CountModel<UserActivity>> GetUserActivitiess(UserActivityQueryParameters userActivityQueryParameters)
        {
            QueryResponse<CountModel<UserActivity>> queryResponse = new QueryResponse<CountModel<UserActivity>>();
            try
            {

                var list = userActivityQuery.GetUserActivities(userActivityQueryParameters);
                var plist = PagedList<UserActivity>.ToPagedIList(list, userActivityQueryParameters.PageNumber, userActivityQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<UserActivity>>.Load(CountModel<UserActivity>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetUserActivitiess)}");
            }
            return queryResponse;
        }

     
    }
}
