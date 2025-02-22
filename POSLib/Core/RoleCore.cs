
using Common.Response;
using Microsoft.Extensions.Logging;
using POSLib.Core.Abstract;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.Repo.Abstract;
using POSLib.Repo.Command;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Core
{
    public class RoleCore : IRoleCore
    {
        IRoleCommand roleCommand;
        IRoleQuery roleQuery;
        ILogger<RoleCore> logger;   
        public RoleCore(IRoleCommand roleCommand,IRoleQuery roleQuery,ILogger<RoleCore> logger)
        {
            this.logger = logger;
            this.roleCommand = roleCommand;
            this.roleQuery = roleQuery;

        }

        public CommandResponse AddRole(RoleAddViewModel roleAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = roleCommand.AddRole(roleAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddRole)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteRole(int id)
        {
            bool result = false;
            try
            {
                result = roleCommand.DeleteRole(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddRole)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Role> GetRole(int id)
        {
            QueryResponse<Role> queryResponse = new QueryResponse<Role>();
            try
            {
                Role role = new Role();

                role = roleQuery.GetRole(id);

                if (role != null)
                {
                    queryResponse = QueryResponse<Role>.Load(role);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetRole)}");
            }
            return queryResponse;
        }

        public QueryResponse<List<Role>> GetRoles(string rolename) 
        {
            QueryResponse<List<Role>> queryResponse = new QueryResponse<List<Role>>();
            try
            {

                var list = roleQuery.GetRoles(rolename);
              
                queryResponse = QueryResponse<List<Role>>.Load(list);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetRoles)}");
            }
            return queryResponse;
        }
    }
}
