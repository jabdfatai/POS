using Common.Model;
using Common.Response;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Core.Abstract
{
   public interface IAlertCore
    {
        public CommandResponse AddAlert(AlertAddViewModel alertAddViewModel);

        public CommandResponse UpdateAlert(int alertid, AlertAddViewModel alertAddViewModel);
        public CommandResponse PatchAlert(int alertid, AlertPatchViewModel alertPatchViewModel);
        public CommandResponse DeleteAlert(int alertid);

        public QueryResponse<CountModel<Alert>> GetAlert(AlertQueryParameters alertQueryParameters);

        public QueryResponse<Alert> GetAlert(int alertid);
        
    }
}
