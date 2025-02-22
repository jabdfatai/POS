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
    public class VendorQuery : IVendorQuery
    {
        InventoryDbContext context;
        ILogger<ProductQuery> logger;
        int resultid = 0;
        public VendorQuery(InventoryDbContext context,ILogger<ProductQuery> logger)
        {
            this.context = context;
            this.logger = logger;   
        }
        public Vendor GetVendor(int vendorid)
        {
            Vendor vendor = new Vendor();
            try
            {
                var query = context.Vendors.Find(vendorid);
                if (query == null)
                {
                    vendor = null;
                }
                else
                {
                    vendor = query;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return vendor;
        }

        public List<Vendor> SearchVendor(VendorQueryParameters vendorQueryParameters)
        {
            List<Vendor> puroederlist = new List<Vendor>();
            try
            {
                var result = context.Vendors.Where(a => a.status == 1);

                if (vendorQueryParameters.descr != null)
                {
                    result = result.Where(a => a.descr.Contains(vendorQueryParameters.descr));
                }
                if (vendorQueryParameters.rcno != null)
                {
                    result = result.Where(a => a.rcno == vendorQueryParameters.rcno);
                }
                if (vendorQueryParameters.phone != null)
                {
                    result = result.Where(a => a.phone.Contains(vendorQueryParameters.phone));
                }

                if (vendorQueryParameters.org_name != null)
                {
                    result = result.Where(a => a.org_name.Contains(vendorQueryParameters.org_name));
                }
                if (vendorQueryParameters.contactname != null)
                {
                    result = result.Where(a => (a.contact_fst_name + a.contact_lst_name).Contains(vendorQueryParameters.contactname));
                }
               
                if (vendorQueryParameters.dtcreatedfrom != null)
                {
                    result = result.Where(a => a.dt_crtd >= vendorQueryParameters.dtcreatedfrom);
                }
                if (vendorQueryParameters.dtcreatedto != null)
                {
                    result = result.Where(a => a.dt_crtd <= vendorQueryParameters.dtcreatedto);
                }
                if (result.Count() > 0)
                {
                    puroederlist = result.OrderBy(b => b.id)
                                            .Skip((vendorQueryParameters.PageNumber - 1) * vendorQueryParameters.PageSize)
                                            .Take(vendorQueryParameters.PageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return puroederlist;
        }
    }
}
