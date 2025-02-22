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
    public class ManfCore : IManfCore
    {
        IManfCommand manfCommand;
        IManfQuery manfQuery;
        ILogger<ManfCore> logger;
        public ManfCore(IManfCommand manfCommand,IManfQuery manfQuery,ILogger<ManfCore> logger)
        {
            this.manfCommand = manfCommand;
            this.manfQuery = manfQuery;
            this.logger = logger;
        }

        public CommandResponse AddManf(ManfAddViewModel manfAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = manfCommand.AddManf(manfAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddManf)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteManf(int manfid)
        {
            bool result = false;
            try
            {
                result = manfCommand.DeleteManf(manfid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteManf)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Manf> GetManf(int manfid)
        {
            QueryResponse<Manf> queryResponse = new QueryResponse<Manf>();
            try
            {
                Manf manf = new Manf();

                manf = manfQuery.GetManf(manfid);

                if (manf != null)
                {
                    queryResponse = QueryResponse<Manf>.Load(manf);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetManf)}");
            }
            return queryResponse;
        }

        public QueryResponse<CountModel<Manf>> SearchManf(ManfQueryParameters manfQueryParameters)
        {
            QueryResponse<CountModel<Manf>> queryResponse = new QueryResponse<CountModel<Manf>>();
            try
            {

                var list = manfQuery.SearchManf(manfQueryParameters);
                var plist = PagedList<Manf>.ToPagedIList(list, manfQueryParameters.PageNumber, manfQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Manf>>.Load(CountModel<Manf>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(SearchManf)}");
            }
            return queryResponse;
        }

        public CommandResponse UpdateManf(int manfid, ManfAddViewModel manfAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = manfCommand.UpdateManf(manfid,manfAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateManf)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
