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
    public interface IUserCommand
    {
        int AddUser(UserAddViewModel userAddViewModel);
        int UpdateUser(Guid userid, UserPatchViewModel userPatchViewModel);
        int PatchUser(Guid userid, UserPatchViewModel userPatchViewModel);
        bool DeleteUser(Guid userid);
    }
    public interface IUserQuery
    {
        List<User> GetUsers(UserQueryParameters userQueryParameters);
        User GetUser(Guid userid);

    }
}
