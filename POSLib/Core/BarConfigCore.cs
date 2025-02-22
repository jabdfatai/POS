
using Common.Model;
using Common.Response;
using Microsoft.Extensions.Logging;
using POSLib.Core.Abstract;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.Repo.Abstract;
using POSLib.Repo.Command;
using POSLib.Repo.Query;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Core
{
    public class BarConfigCore : IBarConfigCore
    {
        IBar_ConfigCommand bar_ConfigCommand;
        IBar_ConfigQuery bar_ConfigQuery;
        ILogger<BarConfigCore> logger;  
        public BarConfigCore(IBar_ConfigCommand bar_ConfigCommand,IBar_ConfigQuery bar_ConfigQuery,
        ILogger<BarConfigCore> logger)
        {
            this.bar_ConfigQuery = bar_ConfigQuery;
            this.bar_ConfigCommand  = bar_ConfigCommand;
            this.logger = logger;

        }
        public CommandResponse AddBarConfig(Bar_ConfigAddViewModel bar_ConfigAddViewModel)
        {

            int resultid = 0;
            try
            {
                resultid = bar_ConfigCommand.AddBarConfig(bar_ConfigAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddBarConfig)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteBarConfig(int id)
        {
            bool result = false;
            try
            {
                result = bar_ConfigCommand.DeleteBarConfig(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteBarConfig)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Bar_Config> GetBarConfig(int id)
        {
            QueryResponse<Bar_Config> queryResponse = new QueryResponse<Bar_Config>();
            try
            {
                Bar_Config bar_Config = new Bar_Config();

                bar_Config = bar_ConfigQuery.GetBarConfig(id);

                if (bar_Config != null)
                {
                    queryResponse = QueryResponse<Bar_Config>.Load(bar_Config);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetBarConfig)}");
            }
            return queryResponse;
        }

        public QueryResponse<CountModel<Bar_Config>> GetBarConfigs(Bar_ConfigQueryParameters bar_ConfigQueryParameters)
        {
            QueryResponse<CountModel<Bar_Config>> queryResponse = new QueryResponse<CountModel<Bar_Config>>();
            try
            {

                var list = bar_ConfigQuery.GetBarConfigs(bar_ConfigQueryParameters);
                var plist = PagedList<Bar_Config>.ToPagedIList(list, bar_ConfigQueryParameters.PageNumber, bar_ConfigQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Bar_Config>>.Load(CountModel<Bar_Config>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetBarConfigs)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchBarConfig(int id, Bar_ConfigPatchViewModel bar_ConfigPatchViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = bar_ConfigCommand.PatchBarConfig(id, bar_ConfigPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchBarConfig)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse UpdateBarConfig(int id, Bar_ConfigPatchViewModel bar_ConfigPatchViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = bar_ConfigCommand.UpdateBarConfig(id, bar_ConfigPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateBarConfig)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
