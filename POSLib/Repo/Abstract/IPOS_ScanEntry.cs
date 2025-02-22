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
    public interface IPOSScanEntryCommand
    {
        int AddEntry(PosScanEntryAddViewModel posScanEntryAddViewModel);
        bool DeleteEntry(int id);
    }
    public interface IPOSScanEntryQuery
    {
        List<PosScanEntry> GetEntries(PosScanEntryQueryParameter posScanEntryQueryParameter);
        PosScanEntry GetEntry(int id);

    }
}
