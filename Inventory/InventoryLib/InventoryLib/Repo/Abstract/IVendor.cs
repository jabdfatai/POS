using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Abstract
{
   public interface IVendorCommand
    {
        int AddVendor(VendorAddViewModel vendorAddViewModel);
        int UpdateVendor(int vendorid, VendorAddViewModel vendorAddViewModel);

        int AddUpdateVendorProduct(VendorProductAddViewModel vendorProductAddViewModel);
        int PatchVendor(int vendorid, VendorPatchViewModel vendorAddViewModel);
        bool DeleteVendor(int vendorid);
    }
    public interface IVendorQuery
    {
        List<Vendor> SearchVendor(VendorQueryParameters vendorQueryParameters);
        Vendor GetVendor(int vendorid);
    }
}
