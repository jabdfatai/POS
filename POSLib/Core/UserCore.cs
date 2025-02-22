using Common.Model;
using Common.Response;
using Microsoft.Extensions.Logging;
using POSLib.Core.Abstract;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.Repo.Abstract;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Core
{
    public class UserCore : IUserCore
    {
        IUserQuery userQuery;
        IUserCommand userCommand;
        ILogger<UserCore> logger;
        public UserCore(IUserQuery userQuery, IUserCommand userCommand, ILogger<UserCore> logger)
        {
            this.userQuery = userQuery;
            this.userCommand = userCommand;
            this.logger = logger;
        }
        public CommandResponse AddUser(UserAddViewModel userAddViewModel)
        {
           
            int resultid = 0;
            try
            {
                resultid = userCommand.AddUser(userAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddUser)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteUser(Guid userid)
        {
            bool result = false;
            try
            {
                result = userCommand.DeleteUser(userid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteUser)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<User> GetUser(Guid userid)
        {
            QueryResponse<User> queryResponse = new QueryResponse<User>();
            try
            {
                User user = new User();

                user = userQuery.GetUser(userid);

                if (user != null)
                {
                    queryResponse = QueryResponse<User>.Load(user);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetUser)}");
            }
            return queryResponse;
        }

        public QueryResponse<CountModel<User>> GetUsers(UserQueryParameters userQueryParameters)
        {
            QueryResponse<CountModel<User>> queryResponse = new QueryResponse<CountModel<User>>();
            try
            {

                var list = userQuery.GetUsers(userQueryParameters);
                var plist = PagedList<User>.ToPagedIList(list, userQueryParameters.PageNumber, userQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<User>>.Load(CountModel<User>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetUsers)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchUser(Guid userid, UserPatchViewModel userPatchViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = userCommand.PatchUser(userid,userPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchUser)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse UpdateUser(Guid userid, UserPatchViewModel userPatchViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = userCommand.UpdateUser(userid, userPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateUser)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
