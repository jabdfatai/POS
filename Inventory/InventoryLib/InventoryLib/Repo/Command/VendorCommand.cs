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
    public class VendorCommand : IVendorCommand
    {
        InventoryDbContext context;
        ILogger<VendorCommand> logger;
        int resultid = 0;
        public VendorCommand(InventoryDbContext context, ILogger<VendorCommand> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public int AddUpdateVendorProduct(VendorProductAddViewModel vendorProductAddViewModel)
        {
            try
            {
                context.Vend_Prods.Add(new Vend_Prod
                {
                    productid = vendorProductAddViewModel.productid,
                    vendorid = vendorProductAddViewModel.vendorid


                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public int AddVendor(VendorAddViewModel vendorAddViewModel)
        {
            try
            {
                context.Vendors.Add(new Vendor
                {
                    descr = vendorAddViewModel.descr


                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteVendor(int vendorid)
        {
            bool deletestatus = false;
            try
            {

                var selvendor = context.Vendors.Find(vendorid);
                selvendor.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        public int PatchVendor(int vendorid, VendorPatchViewModel vendorAddViewModel)
        {
            try
            {
                var selvendor = context.Vendors.Find(vendorid);
                if (selvendor == null)
                {
                    if (vendorAddViewModel.descr != null)
                    {
                        selvendor.descr = vendorAddViewModel.descr;
                    }
                    if (vendorAddViewModel.email != null)
                    {
                        selvendor.email = vendorAddViewModel.email;
                    }
                    if (vendorAddViewModel.phone != null)
                    {
                        selvendor.phone = vendorAddViewModel.phone;
                    }
                    if (vendorAddViewModel.contact_lst_name != null)
                    {
                        selvendor.contact_fst_name = vendorAddViewModel.contact_fst_name;
                    }
                    if (vendorAddViewModel.contact_fst_name != null)
                    {
                        selvendor.contact_fst_name = vendorAddViewModel.contact_fst_name;
                    }
                    if (vendorAddViewModel.rcno != null)
                    {
                        selvendor.rcno = vendorAddViewModel.rcno;
                    }
                   
                    selvendor.dt_modf = DateTime.UtcNow;
                    resultid = context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public int UpdateVendor(int vendorid, VendorAddViewModel vendorAddViewModel)
        {
            try
            {
                var selvendor = context.Vendors.Find(vendorid);
                if (selvendor == null)
                {
                    selvendor.descr = vendorAddViewModel.descr;
                    selvendor.email = vendorAddViewModel.email;
                    selvendor.phone = vendorAddViewModel.phone; 
                    selvendor.contact_fst_name = vendorAddViewModel.contact_fst_name;
                    selvendor.contact_lst_name = vendorAddViewModel.contact_lst_name;
                    selvendor.org_name = vendorAddViewModel.org_name;
                    selvendor.rcno = vendorAddViewModel.rcno;                  
                    selvendor.dt_modf = DateTime.UtcNow;
                    resultid = context.SaveChanges();
                }
              
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }
    }
}
