using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo.Abstract;
using InventoryLib.Server;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Repo.Query
{
    public class LotQuery : IlotQuery
    {
        InventoryDbContext context;
        ILogger<LotQuery> logger;
        int resultid = 0;
        public LotQuery(InventoryDbContext context,ILogger<LotQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public Lot GetLot(int lotid)
        {
            Lot lot = new Lot();
            try
            {
                var query = context.Lots.Find(lotid);
                if (query == null)
                {
                    lot = null;
                }
                else
                {
                    lot = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return lot;
        }

        public List<Lot> SearchLot(LotQueryParameters lotQueryParameters)
        {
            List<Lot> lotlist = new List<Lot>();
            try
            {
                var result = context.Lots.Where(a => a.status == 1);
                if (lotQueryParameters.lotno != null)
                {
                    result = result.Where(a => a.lotno == lotQueryParameters.lotno);
                }
                if (lotQueryParameters.qty != null)
                {
                    result = result.Where(a => a.qty == lotQueryParameters.qty);
                }
                if (lotQueryParameters.minqty != null)
                {
                    result = result.Where(a => a.qty >= lotQueryParameters.qty);
                }
                if (lotQueryParameters.maxqty != null)
                {
                    result = result.Where(a => a.qty <= lotQueryParameters.maxqty);
                }
                if (lotQueryParameters.descr != null)
                {
                    result = result.Where(a => a.descr.Contains(lotQueryParameters.descr));
                }
                if (lotQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= lotQueryParameters.dtcreatedfrom);
                }
                if (lotQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= lotQueryParameters.dtcreatedto);
                }

                if (lotQueryParameters.batch_no != null)
                {
                    result = result.Where(a => a.batch_no == lotQueryParameters.batch_no);
                }
                if (lotQueryParameters.exp_date != null)
                {
                    result = result.Where(a => a.exp_date == lotQueryParameters.exp_date);
                }
                if (lotQueryParameters.exp_date_from != null)
                {
                    result = result.Where(a => a.exp_date >= lotQueryParameters.exp_date_from);
                }
                if (lotQueryParameters.exp_date_to != null)
                {
                    result = result.Where(a => a.exp_date <= lotQueryParameters.exp_date_to);
                }
                if (lotQueryParameters.manf_date != null)
                {
                    result = result.Where(a => a.manf_date == lotQueryParameters.manf_date);
                }
                if (lotQueryParameters.manf_date_from != null)
                {
                    result = result.Where(a => a.manf_date >= lotQueryParameters.manf_date_from);
                }
                if (lotQueryParameters.manf_date_to != null)
                {
                    result = result.Where(a => a.manf_date <= lotQueryParameters.manf_date_to);
                }
                if (lotQueryParameters.pur_ord_id != null)
                {
                    result = result.Where(a => a.pur_ord_id == lotQueryParameters.pur_ord_id);
                }
                if (lotQueryParameters.vend_id != null)
                {
                    result = result.Where(a => a.vend_id == lotQueryParameters.vend_id);
                }

                if (result.Count() > 0)
                {

                    lotlist = result.OrderBy(b => b.id)
                                            .Skip((lotQueryParameters.PageNumber - 1) * lotQueryParameters.PageSize)
                                            .Take(lotQueryParameters.PageSize).ToList();
                }
                
            }

            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return lotlist;
        }
    }
}
