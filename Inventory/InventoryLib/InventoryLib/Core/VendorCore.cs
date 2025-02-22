using Common.Model;
using Common.Response;
using InventoryLib.Core.Abstract;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo.Abstract;
using InventoryLib.Repo.Command;
using InventoryLib.Repo.Query;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Core
{
    public class VendorCore : IVendorCore
    {
        IVendorCommand VendorCommand;
        IVendorQuery VendorQuery;
        ILogger<VendorCore> logger;
        public VendorCore(IVendorCommand VendorCommand,IVendorQuery VendorQuery,ILogger<VendorCore> logger)
        {
            this.VendorCommand = VendorCommand;
            this.VendorQuery = VendorQuery;
            this.logger = logger;
        }

        public CommandResponse AddUpdateVendorProduct(VendorProductAddViewModel vendorProductAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = VendorCommand.AddUpdateVendorProduct(vendorProductAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddVendor)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse AddVendor(VendorAddViewModel VendorAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = VendorCommand.AddVendor(VendorAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddVendor)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteVendor(int Vendorid)
        {
            bool result = false;
            try
            {
                result = VendorCommand.DeleteVendor(Vendorid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteVendor)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Vendor> GetVendor(int Vendorid)
        {
            QueryResponse<Vendor> queryResponse = new QueryResponse<Vendor>();
            try
            {
                Vendor Vendor = new Vendor();

                Vendor = VendorQuery.GetVendor(Vendorid);

                if (Vendor != null)
                {
                    queryResponse = QueryResponse<Vendor>.Load(Vendor);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetVendor)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchVendor(int vendorid, VendorPatchViewModel vendorPatchViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = VendorCommand.PatchVendor(vendorid, vendorPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateVendor)}");
            }
            return CommandResponse.Load(resultid);
        }

        public QueryResponse<CountModel<Vendor>> SearchVendor(VendorQueryParameters VendorQueryParameters)
        {
            QueryResponse<CountModel<Vendor>> queryResponse = new QueryResponse<CountModel<Vendor>>();
            try
            {

                var list = VendorQuery.SearchVendor(VendorQueryParameters);
                var plist = PagedList<Vendor>.ToPagedIList(list, VendorQueryParameters.PageNumber, VendorQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Vendor>>.Load(CountModel<Vendor>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(SearchVendor)}");
            }
            return queryResponse;
        }

        public CommandResponse UpdateVendor(int Vendorid, VendorAddViewModel VendorAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = VendorCommand.UpdateVendor(Vendorid,VendorAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateVendor)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
