
using Common.Model;
using Common.Response;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.ViewModel;

namespace POSLib.Core.Abstract
{
    public interface IUserActivityCore
    {
        public CommandResponse AddUserActivity(UserActivityAddViewModel userActivityAddViewModel);
        public QueryResponse<CountModel<UserActivity>> GetUserActivitiess(UserActivityQueryParameters userActivityQueryParameters);

    }
}
