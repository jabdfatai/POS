using Microsoft.Extensions.Logging;
using POSLib.Model;
using POSLib.QueryParameters;
using POSLib.Repo.Abstract;
using POSLib.Server;
using POSLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Repo.Query
{
    public class Bar_ConfigQuery : IBar_ConfigQuery
    {
        POSDbContext context;
        ILogger<UserActivityQuery> logger;
        int resultid = 0;
        public Bar_ConfigQuery(POSDbContext context,ILogger<UserActivityQuery> logger)
        {
            this.context = context; 
            this.logger = logger;

        }

        public Bar_Config GetBarConfig(int id)
        {
            Bar_Config bar_Config = new Bar_Config();
            try
            {
                var query = context.Bar_Configs.Where(c => c.id == id);
                if (query.Any())
                {
                    bar_Config = query.FirstOrDefault();
                }
                else
                {
                    bar_Config = null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return bar_Config;
        }

        public List<Bar_Config> GetBarConfigs(Bar_ConfigQueryParameters bar_ConfigQueryParameters)
        {
            var list = new List<Bar_Config>();
            try
            {
                var query = context.Bar_Configs.AsQueryable();
                query = query.Where(a => a.STATUS == 1);
                if (bar_ConfigQueryParameters.lotid != null)
                {
                    query = query.Where(a => a.lotid == bar_ConfigQueryParameters.lotid);
                }
                if (bar_ConfigQueryParameters.UPC != null)
                {
                    query = query.Where(a => a.UPC == bar_ConfigQueryParameters.UPC);
                }
                if (bar_ConfigQueryParameters.SKU != null)
                {
                    query = query.Where(a => a.SKU == bar_ConfigQueryParameters.SKU);
                }
                if (bar_ConfigQueryParameters.created_from != null)
                {
                    query = query.Where(a => a.DT_CRTD >= bar_ConfigQueryParameters.created_from);
                }
                if (bar_ConfigQueryParameters.created_to != null)
                {
                    query = query.Where(a => a.DT_CRTD <= bar_ConfigQueryParameters.created_to);
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
