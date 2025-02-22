using InventoryLib.Model;
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
    public class Prod_TypeCommand : IProdTypeCommand
    {
        InventoryDbContext context;
        ILogger<Prod_TypeCommand> logger;
        int resultid = 0;
        public Prod_TypeCommand(InventoryDbContext context, ILogger<Prod_TypeCommand> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public int AddProdType(Prod_TypeAddViewModel prod_TypeAddViewModel)
        {
            try
            {
                context.Prod_Types.Add(new Prod_Type
                {
                    descr = prod_TypeAddViewModel.descr,
                    prod_cat_id = prod_TypeAddViewModel.prod_cat_id

                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteProdType(int prodtypeid)
        {
            bool deletestatus = false;
            try
            {

                var selprodtyperec = context.Prod_Types.Find(prodtypeid);
                selprodtyperec.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int UpdateProdType(int prodtypeid, Prod_TypeAddViewModel prod_TypeAddViewModel)
        {
            try
            {
                var selprodtyperec = context.Prod_Types.Find(prodtypeid);
                selprodtyperec.descr = prod_TypeAddViewModel.descr;
                selprodtyperec.prod_cat_id = prod_TypeAddViewModel.prod_cat_id;
                selprodtyperec.dt_modf = DateTime.UtcNow;
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
