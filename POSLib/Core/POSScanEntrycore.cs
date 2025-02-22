
using Common.Model;
using Common.Response;
using Microsoft.Extensions.Logging;
using POSLib.Core.Abstract;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.Repo.Abstract;
using POSLib.Repo.Query;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Core
{
    public class POSScanEntrycore : IPOSScanEntryCore
    {
        IPOSScanEntryCommand pOSScanEntryCommand;
        IBar_ConfigQuery bar_ConfigQuery;
        IPOSScanEntryQuery pOSScanEntryQuery;
        ILogger<POSScanEntrycore> logger;
        public POSScanEntrycore(IPOSScanEntryCommand pOSScanEntryCommand, IBar_ConfigQuery bar_ConfigQuery, IPOSScanEntryQuery pOSScanEntryQuery,
        ILogger<POSScanEntrycore> logger)
        {
            this.pOSScanEntryQuery = pOSScanEntryQuery;
            this.logger = logger;
            this.pOSScanEntryCommand = pOSScanEntryCommand;
            this.bar_ConfigQuery = bar_ConfigQuery;

        }
        public CommandResponse AddScanEntry(PosScanEntryAddViewModel posScanEntryAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = pOSScanEntryCommand.AddEntry(posScanEntryAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddScanEntry)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteScanEntry(int id)
        {
            bool result = false;
            try
            {
                result = pOSScanEntryCommand.DeleteEntry(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteScanEntry)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<CountModel<PosScanEntry>> GetEntries(PosScanEntryQueryParameter posScanEntryQueryParameters)
        {
            QueryResponse<CountModel<PosScanEntry>> queryResponse = new QueryResponse<CountModel<PosScanEntry>>();
            try
            {

                var list = pOSScanEntryQuery.GetEntries(posScanEntryQueryParameters);
                var plist = PagedList<PosScanEntry>.ToPagedIList(list, posScanEntryQueryParameters.PageNumber, posScanEntryQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<PosScanEntry>>.Load(CountModel<PosScanEntry>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetEntries)}");
            }
            return queryResponse;
        }

        public QueryResponse<PosScanEntry> GetEntry(int id)
        {
            QueryResponse<PosScanEntry> queryResponse = new QueryResponse<PosScanEntry>();
            try
            {
                PosScanEntry posScanEntry = new PosScanEntry();

                posScanEntry = pOSScanEntryQuery.GetEntry(id);

                if (posScanEntry != null)
                {
                    queryResponse = QueryResponse<PosScanEntry>.Load(posScanEntry);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetEntry)}");
            }
            return queryResponse;
        }

       public QueryResponse<string> ScanProduct()
        {
            return QueryResponse<string>.Load("");

        }
    }
}
