
using Common.Response;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.ViewModel;

namespace POSLib.Core.Abstract
{
    public interface IRoleCore
    {
        public CommandResponse AddRole(RoleAddViewModel roleAddViewModel);
        public CommandResponse DeleteRole(int id);
        public QueryResponse<List<Role>> GetRoles(string rolename);

        public QueryResponse<Role> GetRole(int id);
    }
}
