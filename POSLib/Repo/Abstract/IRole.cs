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
    public interface IRoleCommand
    {
        int AddRole(RoleAddViewModel roleAddViewModel);
        bool DeleteRole(int roleid);
    }
    public interface IRoleQuery
    {
        List<Role> GetRoles(string rolename);
        Role GetRole(int roleid);
    }
}
