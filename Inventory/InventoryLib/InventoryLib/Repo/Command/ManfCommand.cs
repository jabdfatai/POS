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
    public class ManfCommand : IManfCommand
    {
        InventoryDbContext context;
        ILogger<ManfCommand> logger;
        int resultid = 0;
        public ManfCommand(InventoryDbContext context, ILogger<ManfCommand> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public int AddManf(ManfAddViewModel manfAddViewModel)
        {
            try
            {
                context.Manfs.Add(new Manf
                {
                    descr = manfAddViewModel.descr


                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteManf(int manfid)
        {
            bool deletestatus = false;
            try
            {

                var selmanfrec = context.Manfs.Find(manfid);
                selmanfrec.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int UpdateManf(int manfid, ManfAddViewModel manfAddViewModel)
        {
            try
            {
                var selmanfrec = context.Manfs.Find(manfid);
                selmanfrec.descr = manfAddViewModel.descr;
                selmanfrec.dt_modf = DateTime.UtcNow;
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
