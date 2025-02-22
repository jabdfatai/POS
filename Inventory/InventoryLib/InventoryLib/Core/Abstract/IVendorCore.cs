using InventoryLib.Model;
using InventoryLib.QueryParameters;
using Common.Model;
using InventoryLib.ViewModel;
using Common.Response;

namespace InventoryLib.Core.Abstract
{
    public interface IVendorCore
    {
        CommandResponse AddVendor(VendorAddViewModel vendorAddViewModel);
        CommandResponse UpdateVendor(int vendorid, VendorAddViewModel vendorAddViewModel);

        CommandResponse AddUpdateVendorProduct(VendorProductAddViewModel vendorProductAddViewModel);
        CommandResponse PatchVendor(int vendorid, VendorPatchViewModel vendorAddViewModel);
        CommandResponse DeleteVendor(int vendorid);
        QueryResponse<CountModel<Vendor>> SearchVendor(VendorQueryParameters vendorQueryParameters);
        QueryResponse<Vendor> GetVendor(int vendorid);
    }

}
