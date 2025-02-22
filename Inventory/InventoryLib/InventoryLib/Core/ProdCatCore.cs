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
    public class ProdCatCore : IProdCatCore
    {
        IProdCatCommand ProdCatCommand;
        IProdCatQuery ProdCatQuery;
        ILogger<ProdCatCore> logger;
        public ProdCatCore(IProdCatCommand ProdCatCommand,IProdCatQuery ProdCatQuery,ILogger<ProdCatCore> logger)
        {
            this.ProdCatCommand = ProdCatCommand;
            this.ProdCatQuery = ProdCatQuery;
            this.logger = logger;
        }

        public CommandResponse AddProdCat(Prod_CatAddViewModel ProdCatAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = ProdCatCommand.AddProdCat(ProdCatAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddProdCat)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteProdCat(int ProdCatid)
        {
            bool result = false;
            try
            {
                result = ProdCatCommand.DeleteProdCat(ProdCatid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteProdCat)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Prod_Cat> GetProdCat(int ProdCatid)
        {
            QueryResponse<Prod_Cat> queryResponse = new QueryResponse<Prod_Cat>();
            try
            {
                Prod_Cat ProdCat = new Prod_Cat();

                ProdCat = ProdCatQuery.GetProdCat(ProdCatid);

                if (ProdCat != null)
                {
                    queryResponse = QueryResponse<Prod_Cat>.Load(ProdCat);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetProdCat)}");
            }
            return queryResponse;
        }

        public QueryResponse<CountModel<Prod_Cat>> SearchProdCat(Prod_CatQueryParameters ProdCatQueryParameters)
        {
            QueryResponse<CountModel<Prod_Cat>> queryResponse = new QueryResponse<CountModel<Prod_Cat>>();
            try
            {

                var list = ProdCatQuery.SearchProdCategory(ProdCatQueryParameters);
                var plist = PagedList<Prod_Cat>.ToPagedIList(list, ProdCatQueryParameters.PageNumber, ProdCatQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Prod_Cat>>.Load(CountModel<Prod_Cat>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(SearchProdCat)}");
            }
            return queryResponse;
        }

        public CommandResponse UpdateProdCat(int ProdCatid, Prod_CatAddViewModel ProdCatAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = ProdCatCommand.UpdateProdCat(ProdCatid,ProdCatAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(UpdateProdCat)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
