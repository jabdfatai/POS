using Microsoft.Extensions.Logging;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.Repo.Abstract;
using POSLib.Server;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Repo.Query
{
    public class POSScanEntry : IPOSScanEntryQuery
    {
        POSDbContext context;
        ILogger<POSScanEntry> logger;
        int resultid = 0;
        public POSScanEntry(POSDbContext context, ILogger<POSScanEntry> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public PosScanEntry GetEntry(int id)
        {
            PosScanEntry posScanEntry = new PosScanEntry();
            try
            {
                var query = context.PosScanEntries.Where(c => c.id == id);
                if (query.Any())
                {
                    posScanEntry = query.FirstOrDefault();
                }
                else
                {
                    posScanEntry = null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return posScanEntry;
        }


        public List<PosScanEntry> GetEntries(PosScanEntryQueryParameter posScanEntryQueryParameter)
        {
            var list = new List<PosScanEntry>();
            try
            {
                var query = context.PosScanEntries.AsQueryable();
                query = query.Where(a => a.STATUS == 1);
                if (posScanEntryQueryParameter.userid != null)
                {
                    query = query.Where(a => a.userid == posScanEntryQueryParameter.userid);
                }
                if (posScanEntryQueryParameter.dir != null)
                {
                    query = query.Where(a => a.dir == posScanEntryQueryParameter.dir);
                }
                if (posScanEntryQueryParameter.source != null)
                {
                    query = query.Where(a => a.source == posScanEntryQueryParameter.source);
                }

                if (posScanEntryQueryParameter.UPC != null)
                {
                    query = query.Where(a => a.UPC == posScanEntryQueryParameter.UPC);
                }

                if (posScanEntryQueryParameter.fromscandate != null)
                {
                    query = query.Where(a => a.scandate >= posScanEntryQueryParameter.fromscandate);
                }
                if (posScanEntryQueryParameter.toscandate != null)
                {
                    query = query.Where(a => a.scandate <= posScanEntryQueryParameter.toscandate);
                }

                if (query.Count() > 0)
                {
                    list = query.ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return list;
        }
    }
}
