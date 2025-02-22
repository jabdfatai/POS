using Common.Model;
using Common.Response;
using InventoryLib.Core.Abstract;
using InventoryLib.Model;
using InventoryLib.QueryParameters;
using InventoryLib.Repo;
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
    public class ProdTypeCore : IProdTypeCore
    {
        IProdTypeCommand ProdTypeCommand;
        IProdTypeQuery ProdTypeQuery;
        ILogger<ProdTypeCore> logger;
        public ProdTypeCore(IProdTypeCommand ProdTypeCommand,IProdTypeQuery ProdTypeQuery,ILogger<ProdTypeCore> logger)
        {
            this.ProdTypeCommand = ProdTypeCommand;
            this.ProdTypeQuery = ProdTypeQuery;
            this.logger = logger;
        }

        public CommandResponse AddProdType(Prod_TypeAddViewModel ProdTypeAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = ProdTypeCommand.AddProdType(ProdTypeAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddProdType)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteProdType(int ProdTypeid)
        {
            bool result = false;
            try
            {
                result = ProdTypeCommand.DeleteProdType(ProdTypeid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteProdType)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Prod_Type> GetProdType(int ProdTypeid)
        {
            QueryResponse<Prod_Type> queryResponse = new QueryResponse<Prod_Type>();
            try
            {
                Prod_Type ProdType = new Prod_Type();

                ProdType = ProdTypeQuery.GetProdType(ProdTypeid);

                if (ProdType != null)
                {
                    queryResponse = QueryResponse<Prod_Type>.Load(ProdType);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetProdType)}");
            }
            return queryResponse;
        }

        public QueryResponse<CountModel<Prod_Type>> SearchProdType(ProductTypeQueryParameters ProdTypeQueryParameters)
        {
            QueryResponse<CountModel<Prod_Type>> queryResponse = new QueryResponse<CountModel<Prod_Type>>();
            try
            {

                var list = ProdTypeQuery.SearchProdType(ProdTypeQueryParameters);
                var plist = PagedList<Prod_Type>.ToPagedIList(list, ProdTypeQueryParameters.PageNumber, ProdTypeQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Prod_Type>>.Load(CountModel<Prod_Type>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(SearchProdType)}");
            }
            return queryResponse;
        }

        public CommandResponse UpdateProdType(int ProdTypeid, Prod_TypeAddViewModel ProdTypeAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = ProdTypeCommand.UpdateProdType(ProdTypeid,ProdTypeAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateProdType)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
