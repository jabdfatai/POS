using Common.Model;
using Common.Response;
using InventoryLib.Core.Abstract;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo.Abstract;
using InventoryLib.Repo.Command;
using InventoryLib.Repo.Query;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Core
{
    public class MeasCore : IMeasCore
    {
        IMeasCommand MeasCommand;
        IMeasQuery MeasQuery;
        ILogger<MeasCore> logger;
        public MeasCore(IMeasCommand MeasCommand,IMeasQuery MeasQuery,ILogger<MeasCore> logger)
        {
            this.MeasCommand = MeasCommand;
            this.MeasQuery = MeasQuery;
            this.logger = logger;
        }

        public CommandResponse AddMeas(MeasAddViewModel MeasAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = MeasCommand.AddMeas(MeasAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddMeas)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteMeas(int Measid)
        {
            bool result = false;
            try
            {
                result = MeasCommand.DeleteMeas(Measid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteMeas)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Mea> GetMea(int Measid)
        {
            QueryResponse<Mea> queryResponse = new QueryResponse<Mea>();
            try
            {
                Mea Meas = new Mea();

                Meas = MeasQuery.GetMeas(Measid);

                if (Meas != null)
                {
                    queryResponse = QueryResponse<Mea>.Load(Meas);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetMea)}");
            }
            return queryResponse;
        }

        public QueryResponse<CountModel<Mea>> SearchMeas(MeasQueryParameters MeasQueryParameters)
        {
            QueryResponse<CountModel<Mea>> queryResponse = new QueryResponse<CountModel<Mea>>();
            try
            {

                var list = MeasQuery.SearchMeas(MeasQueryParameters);
                var plist = PagedList<Mea>.ToPagedIList(list, MeasQueryParameters.PageNumber, MeasQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Mea>>.Load(CountModel<Mea>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(SearchMeas)}");
            }
            return queryResponse;
        }

        public CommandResponse UpdateMeas(int Measid, MeasAddViewModel MeasAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = MeasCommand.UpdateMeas(Measid,MeasAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateMeas)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
