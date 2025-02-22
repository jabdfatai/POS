using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo.Abstract;
using InventoryLib.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryLib.Repo.Query
{
    public class AlertQuery : IAlertQuery
    {
        InventoryDbContext context;
        public AlertQuery(InventoryDbContext _context)
        {
            context = _context;
        }
        public Alert GetAlert(int alertid)
        {
            Alert alert = new Alert();
            try
            {
                alert = context.Alerts.Find(alertid);
            }
            catch (Exception ex)
            {

            }
            return alert;

        }
        public List<Alert> GetAlerts(AlertQueryParameters alertQueryParameters)
        {
            List<Alert> alertlist = new List<Alert>();
            try
            {
                var result = context.Alerts.AsQueryable(); ;
                if (!string.IsNullOrEmpty(alertQueryParameters.rec_email))
                {
                    result = result.Where(a => a.rec_email == alertQueryParameters.rec_email);
                }

                if (!string.IsNullOrEmpty(alertQueryParameters.rec_sms))
                {
                    result = result.Where(a => a.rec_sms == alertQueryParameters.rec_sms);
                }

                if (!string.IsNullOrEmpty(alertQueryParameters.del_status))
                {
                    result = result.Where(a => a.del_status == alertQueryParameters.del_status);
                }

                if (alertQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= alertQueryParameters.dtcreatedfrom);
                }

                if (alertQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= alertQueryParameters.dtcreatedto);
                }

                alertlist = result.ToList();
            }
            catch (Exception ex)
            {

            }

            return alertlist;
        }
    }
}
