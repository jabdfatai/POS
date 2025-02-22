using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Repo.Abstract
{
    public interface IUserActivityCommand
    {
        int AddUserActivity(UserActivityAddViewModel userActivityAddViewModel);
    }
    public interface IUserActivityQuery
    {
        List<UserActivity> GetUserActivities(UserActivityQueryParameters userActivityQueryParameters);
   
    }
}
