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
    public interface IBar_ConfigCommand
    {
        int AddBarConfig(Bar_ConfigAddViewModel bar_ConfigAddViewModel);
        int UpdateBarConfig(int id, Bar_ConfigPatchViewModel bar_ConfigPatchViewModel);
        int PatchBarConfig(int id, Bar_ConfigPatchViewModel bar_ConfigPatchViewModel);
        bool DeleteBarConfig(int id);
    }
    public interface IBar_ConfigQuery
    {
        List<Bar_Config> GetBarConfigs(Bar_ConfigQueryParameters bar_ConfigQueryParameters);
        Bar_Config GetBarConfig(int id);
    }
}
