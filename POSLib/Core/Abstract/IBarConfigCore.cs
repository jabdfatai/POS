
using Common.Model;
using Common.Response;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.ViewModel;

namespace POSLib.Core.Abstract
{
    public interface IBarConfigCore
    {
        public CommandResponse AddBarConfig(Bar_ConfigAddViewModel bar_ConfigAddViewModel);

        public CommandResponse UpdateBarConfig(int id, Bar_ConfigPatchViewModel bar_ConfigPatchViewModel);
        public CommandResponse PatchBarConfig(int id, Bar_ConfigPatchViewModel bar_ConfigPatchViewModel);
        public CommandResponse DeleteBarConfig(int id);

        public QueryResponse<CountModel<Bar_Config>> GetBarConfigs(Bar_ConfigQueryParameters bar_ConfigQueryParameters);

        public QueryResponse<Bar_Config> GetBarConfig(int id);
    }
}
