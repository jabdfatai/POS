using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo.Abstract;
using InventoryLib.Server;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Repo.Query
{
    public class ManfQuery : IManfQuery
    {
        InventoryDbContext context;
        ILogger<ManfQuery> logger;
        int resultid = 0;
        public ManfQuery(InventoryDbContext context,ILogger<ManfQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }

        public Manf GetManf(int manfid)
        {
            Manf manf = new Manf();
            try
            {
                var query = context.Manfs.Find(manfid);
                if (query == null)
                {
                    manf = null;
                }
                else
                {
                    manf = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return manf;
        }

        public List<Manf> SearchManf(ManfQueryParameters manfQueryParameters)
        {
            List<Manf> manflist = new List<Manf>();
            try
            {
                var result = context.Manfs.Where(a => a.status == 1);
                if (manfQueryParameters.descr != null)
                {
                  result = result.Where(a => a.descr.Contains(manfQueryParameters.descr));
                }
                if (manfQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= manfQueryParameters.dtcreatedfrom);
                }
                if (manfQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= manfQueryParameters.dtcreatedto);
                }
                if (result.Count() > 0)
                {
                    manflist = result.OrderBy(b => b.id)
                                            .Skip((manfQueryParameters.PageNumber - 1) * manfQueryParameters.PageSize)
                                            .Take(manfQueryParameters.PageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return manflist;
        }
    }
}
