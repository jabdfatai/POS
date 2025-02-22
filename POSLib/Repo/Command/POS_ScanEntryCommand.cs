using Microsoft.Extensions.Logging;
using POSLib.Model;
using POSLib.Repo.Abstract;
using POSLib.Server;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Repo.Command
{
    public class POS_ScanEntryCommand : IPOSScanEntryCommand
    {
        POSDbContext context;
        ILogger<Bar_ConfigCommand> logger;
        int resultid = 0;
        public POS_ScanEntryCommand(POSDbContext context,ILogger<Bar_ConfigCommand> logger)
        {
            this.context = context; 
            this.logger = logger;
        }
        public int AddEntry(PosScanEntryAddViewModel posScanEntryAddViewModel)
        {
            try
            {
                context.PosScanEntries.Add(new PosScanEntry
                {
                   dir = posScanEntryAddViewModel.dir,
                   scandate = posScanEntryAddViewModel.scandate,
                   scantime = posScanEntryAddViewModel.scantime,    
                   source = posScanEntryAddViewModel.source,
                   UPC = posScanEntryAddViewModel.UPC,  
                   userid = posScanEntryAddViewModel.userid
                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteEntry(int id)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.PosScanEntries.Find(id);
                selrec.STATUS = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }
    }
}
