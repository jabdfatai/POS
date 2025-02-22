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
    public class Bar_ConfigCommand : IBar_ConfigCommand
    {

        POSDbContext context;
        ILogger<Bar_ConfigCommand> logger;
        int resultid = 0;
        public Bar_ConfigCommand(POSDbContext context, ILogger<Bar_ConfigCommand> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public int AddBarConfig(Bar_ConfigAddViewModel bar_ConfigAddViewModel)
        {
            try
            {
                context.Bar_Configs.Add(new Bar_Config
                {
                   lotid = bar_ConfigAddViewModel.lotid,
                   SKU = bar_ConfigAddViewModel.SKU,    
                   UPC = bar_ConfigAddViewModel.UPC

                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteBarConfig(int id)
        {
            bool deletestatus = false;
            try
            {

                var selrec = context.Bar_Configs.Find(id);
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

        public int PatchBarConfig(int id, Bar_ConfigPatchViewModel bar_ConfigPatchViewModel)
        {
            try
            {
                var selrec = context.Bar_Configs.Find(id);
                selrec.SKU = string.IsNullOrEmpty(bar_ConfigPatchViewModel.SKU) ? selrec.SKU : bar_ConfigPatchViewModel.SKU;
                selrec.lotid = bar_ConfigPatchViewModel.lotid == null ? selrec.lotid : bar_ConfigPatchViewModel.lotid.Value;
      
                selrec.DT_MODF = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public int UpdateBarConfig(int id, Bar_ConfigPatchViewModel bar_ConfigPatchViewModel)
        {
            try
            {
                var selrec = context.Bar_Configs.Find(id);
                selrec.SKU = bar_ConfigPatchViewModel.SKU;
                selrec.lotid = bar_ConfigPatchViewModel.lotid.Value;
                selrec.UPC = bar_ConfigPatchViewModel.UPC;
                selrec.DT_MODF = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }
    }
}
