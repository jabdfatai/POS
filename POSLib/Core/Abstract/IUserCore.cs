
using Common.Model;
using Common.Response;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Core.Abstract
{
    public interface IUserCore
    {
        public CommandResponse AddUser(UserAddViewModel userAddViewModel);

        public CommandResponse UpdateUser(Guid userid, UserPatchViewModel userPatchViewModel);
        public CommandResponse PatchUser(Guid userid, UserPatchViewModel userPatchViewModel);
        public CommandResponse DeleteUser(Guid userid);

        public QueryResponse<CountModel<User>> GetUsers(UserQueryParameters userQueryParameters);

        public QueryResponse<User> GetUser(Guid userid);
    }
}
