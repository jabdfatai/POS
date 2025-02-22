
using Common.Model;
using Common.Response;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.ViewModel;

namespace POSLib.Core.Abstract
{
    public interface IPOSScanEntryCore
    {
        public CommandResponse AddScanEntry(PosScanEntryAddViewModel posScanEntryAddViewModel);

        public CommandResponse DeleteScanEntry(int id);

        public QueryResponse<CountModel<PosScanEntry>> GetEntries(PosScanEntryQueryParameter posScanEntryQueryParameters);

        public QueryResponse<PosScanEntry> GetEntry(int id);

        public QueryResponse<string> ScanProduct();


    }
}
