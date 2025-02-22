using Common.Model;
using Common.Response;
using InventoryLib.Core.Abstract;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo.Abstract;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Core
{
    public class AlertCore : IAlertCore
    {
        IAlertCommand alertCommand;
        IAlertQuery alertQuery;
        ILogger<AlertCore> logger;

        public AlertCore(IAlertCommand alertCommand, IAlertQuery alertQuery, ILogger<AlertCore> logger)
        {
            this.alertCommand = alertCommand;
            this.alertQuery = alertQuery;
            this.logger = logger;
        }
        public CommandResponse AddAlert(AlertAddViewModel alertAddViewModel)
        {
            int alertid = 0;
            try
            {
                alertid = alertCommand.AddAlert(alertAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddAlert)}");
            }
            return CommandResponse.Load(alertid);
        }

        public CommandResponse DeleteAlert(int alertid)
        {
            bool delalert = false;
            try
            {
                delalert = alertCommand.DeleteAlert(alertid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteAlert)}");
            }
            return CommandResponse.Load(delalert);
        }

        public QueryResponse<Alert> GetAlert(int alertid)
        {
            QueryResponse<Alert> queryResponse = new QueryResponse<Alert>();
            try
            {
                Alert alert  = new Alert();
                if (alertid > 0)
                {
                    alert = alertQuery.GetAlert(alertid);
                    queryResponse = QueryResponse<Alert>.Load(alert);
                }

               
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetAlert)}");
            }


            return queryResponse;
        }
        public CommandResponse PatchAlert(int alertid, AlertPatchViewModel alertPatchViewModel)
        {
            int res = 0;
            try
            {
              res = alertCommand.PatchAlert(alertid, alertPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchAlert)}");
            }
            return CommandResponse.Load(res);
        }

        public CommandResponse UpdateAlert(int alertid, AlertAddViewModel alertAddViewModel)
        {
            int res = 0;
            try
            {
                res = alertCommand.UpdateAlert(alertid, alertAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateAlert)}");
            }
            return CommandResponse.Load(res);
        }

        QueryResponse<CountModel<Alert>> IAlertCore.GetAlert(AlertQueryParameters alertQueryParameters)
        {
            QueryResponse<CountModel<Alert>> queryResponse = new QueryResponse<CountModel<Alert>>();
            try
            {

                var alertlist = alertQuery.GetAlerts(alertQueryParameters);
                var plist = PagedList<Alert>.ToPagedIList(alertlist, alertQueryParameters.PageNumber, alertQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Alert>>.Load(CountModel<Alert>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetAlert)}");
            }
            return queryResponse;
        }
    }
}
