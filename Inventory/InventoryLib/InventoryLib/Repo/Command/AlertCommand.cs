using InventoryLib.Model;
using InventoryLib.Repo.Abstract;
using InventoryLib.Server;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Command
{
    public class AlertCommand : IAlertCommand
    {
        InventoryDbContext context;
        int resultid = 0;
        public AlertCommand(InventoryDbContext _context)
        {
            context = _context;
        }
        public int AddAlert(AlertAddViewModel alertAddViewModel)
        {            
            try
            {
                context.Alerts.Add(new Alert
                {
                    del_status = alertAddViewModel.del_status,
                    msg_body = alertAddViewModel.msg_body,
                    msg_event = alertAddViewModel.msg_event,
                    rec_email = alertAddViewModel.rec_email,
                    rec_sms = alertAddViewModel.rec_sms,
                    dt_crtd = DateTime.UtcNow
                }
                );
                 resultid = context.SaveChanges();
               
             }
            catch (Exception ex)
            {

            }
            return resultid;
        }

        public bool DeleteAlert(int alertid)
        {
            bool deletestatus = false;
            try
            {
                var selalertrec = context.Alerts.Find(alertid);
                selalertrec.status = 0;
               resultid =  context.SaveChanges();
                deletestatus = resultid > 0 ?true : false;

            }
            catch (Exception ex)
            {

            }
            return deletestatus;
        }

        public int PatchAlert(int alertid, AlertPatchViewModel alertPatchViewModel)
        {
           
            try
            {
                var selalertrec = context.Alerts.Find(alertid);
                selalertrec.del_status = alertPatchViewModel.del_status;
                resultid = context.SaveChanges();
                

            }
            catch (Exception ex)
            {

            }
            return resultid;

        }

        public int UpdateAlert(int alertid, AlertAddViewModel alertAddViewModel)
        {
            try
            {
                var selalertrec = context.Alerts.Find(alertid);
                selalertrec.del_status = alertAddViewModel.del_status;
                selalertrec.msg_body = alertAddViewModel.msg_body;
                selalertrec.msg_event = alertAddViewModel.msg_event;
                selalertrec.rec_email = alertAddViewModel.rec_email;
                selalertrec.rec_sms = alertAddViewModel.rec_sms;
                selalertrec.dt_modf = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return resultid;
        }
    }
}
