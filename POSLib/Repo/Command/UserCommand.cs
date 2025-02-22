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
    public class UserCommand : IUserCommand
    {
        POSDbContext context;
        ILogger<UserCommand> logger;
        int resultid = 0;
        public UserCommand(POSDbContext context,ILogger<UserCommand> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public int AddUser(UserAddViewModel userAddViewModel)
        {
            try
            {
                context.Users.Add(new User
                {
                 email = userAddViewModel.email,
                 fullname = userAddViewModel.fullname,
                 password = userAddViewModel.password,
                 phone = userAddViewModel.phone,    
                 roleid = userAddViewModel.roleid,  
                 userid = userAddViewModel.userid,
                 username = userAddViewModel.username
                 
                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteUser(Guid userid)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.Users.Find(userid);
                selrec.STATUS = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int PatchUser(Guid userid, UserPatchViewModel userPatchViewModel)
        {
            try
            {
                var selrec = context.Users.Find(userid);
                selrec.username =  string.IsNullOrEmpty(userPatchViewModel.username) ? selrec.username: userPatchViewModel.username;
                selrec.password =  string.IsNullOrEmpty(userPatchViewModel.password) ? selrec.password : userPatchViewModel.password;
                selrec.roleid = userPatchViewModel.roleid == null ? selrec.roleid : userPatchViewModel.roleid.Value;
                selrec.userid = userPatchViewModel.userid == null ? selrec.userid : userPatchViewModel.userid.Value;
                selrec.email =  string.IsNullOrEmpty(userPatchViewModel.email) ? selrec.email : userPatchViewModel.email;
                selrec.phone = string.IsNullOrEmpty(userPatchViewModel.phone) ? selrec.phone : userPatchViewModel.phone;
                selrec.fullname = string.IsNullOrEmpty(userPatchViewModel.fullname) ? selrec.fullname : userPatchViewModel.fullname;
                selrec.DT_MODF = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public int UpdateUser(Guid userid, UserPatchViewModel userPatchViewModel)
        {
            try
            {
                var selrec = context.Users.Find(userid);
                selrec.username = userPatchViewModel.username;
                selrec.password = userPatchViewModel.password;
                selrec.roleid = userPatchViewModel.roleid.Value;
                selrec.userid = userid;
                selrec.email = userPatchViewModel.email;
                selrec.phone = userPatchViewModel.phone;
                selrec.fullname = userPatchViewModel.fullname;          
                selrec.DT_MODF = DateTime.UtcNow;
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
