using InventoryLib.Model;
using InventoryLib.Repo.Abstract;
using InventoryLib.Server;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Repo.Command
{
    public class MeasCommand:IMeasCommand
    {
        InventoryDbContext context;
        ILogger<MeasCommand> logger;
        int resultid = 0;
        public MeasCommand(InventoryDbContext context, ILogger<MeasCommand> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public int AddMeas(MeasAddViewModel measAddViewModel)
        {
            try
            {
                context.Meas.Add(new Mea
                {
                   descr = measAddViewModel.descr

                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteMeas(int measid)
        {
            bool deletestatus = false;
            try
            {

                var selmeasrec = context.Meas.Find(measid);
                selmeasrec.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int UpdateMeas(int measid, MeasAddViewModel measAddViewModel)
        {
            try
            {
                var selmeasrec = context.Meas.Find(measid);
                selmeasrec.descr = measAddViewModel.descr;
                selmeasrec.dt_modf = DateTime.UtcNow;
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
