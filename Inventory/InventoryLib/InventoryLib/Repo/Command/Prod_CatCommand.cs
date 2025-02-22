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
    public class Prod_CatCommand : IProdCatCommand
    {
        InventoryDbContext context;
        ILogger<Prod_CatCommand> logger;
        int resultid = 0;
        public Prod_CatCommand(InventoryDbContext context, ILogger<Prod_CatCommand> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public int AddProdCat(Prod_CatAddViewModel prod_CatAddViewModel)
        {
            try
            {
                context.Prod_Cats.Add(new Prod_Cat
                {
                    descr = prod_CatAddViewModel.descr,
                    prod_form = prod_CatAddViewModel.prod_form

                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteProdCat(int prodcatid)
        {
            bool deletestatus = false;
            try
            {

                var selprodcatrec = context.Prod_Cats.Find(prodcatid);
                selprodcatrec.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int UpdateProdCat(int prodcatid, Prod_CatAddViewModel prod_CatAddViewModel)
        {
            try
            {
                var selprodcatrec = context.Prod_Cats.Find(prodcatid);
                selprodcatrec.descr = prod_CatAddViewModel.descr;
                selprodcatrec.prod_form = prod_CatAddViewModel.prod_form;
                selprodcatrec.dt_modf = DateTime.UtcNow;
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
