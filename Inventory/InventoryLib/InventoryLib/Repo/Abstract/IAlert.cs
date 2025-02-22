using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Abstract
{
  public  interface IAlertCommand
    {
        int AddAlert(AlertAddViewModel alertAddViewModel);
        int UpdateAlert(int alertid,AlertAddViewModel alertAddViewModel);
        int PatchAlert(int alertid, AlertPatchViewModel alertPatchViewModel);
        bool DeleteAlert(int alertid);
    }
    public interface IAlertQuery
    {
        List<Alert> GetAlerts(AlertQueryParameters alertQueryParameters);
        Alert GetAlert(int alertid);

    }
}
