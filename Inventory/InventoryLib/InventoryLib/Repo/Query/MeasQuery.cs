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
    public class MeasQuery : IMeasQuery
    {
        InventoryDbContext context;
        ILogger<MeasQuery> logger;
        int resultid = 0;
        public MeasQuery(InventoryDbContext context,ILogger<MeasQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }

        public Mea GetMeas(int measid)
        {
            Mea meas  = new Mea();
            try
            {
                var query = context.Meas.Find(measid);
                if (query == null)
                {
                    meas = null;
                }
                else
                {
                    meas = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return meas;
        }

        public List<Mea> SearchMeas(MeasQueryParameters measQueryParameters)
        {
            List<Mea> mealist = new List<Mea>();
            try
            {
                var result = context.Meas.Where(a => a.status == 1);
                if (measQueryParameters.descr != null)
                {
                  result = result.Where(a => a.descr.Contains(measQueryParameters.descr));
                }
                if (measQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= measQueryParameters.dtcreatedfrom);
                }
                if (measQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= measQueryParameters.dtcreatedto);
                }
                if (result.Count() > 0)
                {
                    mealist = result.OrderBy(b => b.id)
                                            .Skip((measQueryParameters.PageNumber - 1) * measQueryParameters.PageSize)
                                            .Take(measQueryParameters.PageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return mealist;
        }
    }
}
