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
    public class LotCore : ILotCore
    {
        IlotCommand lotCommand;
        IlotQuery lotQuery;
        ILogger<LotCore> logger;
        public LotCore(IlotCommand lotCommand, IlotQuery lotQuery, ILogger<LotCore> logger)
        {
            this.lotQuery = lotQuery;
            this.lotCommand = lotCommand;
            this.logger = logger;
        }
        public CommandResponse AddLot(LotAddViewModel lotAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = lotCommand.AddLot(lotAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddLot)}");
            }
            return CommandResponse.Load(resultid);
        }

        public CommandResponse DeleteLot(int lotid)
        {
            bool result = false;
            try
            {
                result = lotCommand.DeleteLot(lotid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeleteLot)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Lot> GetLot(int lotid)
        {
            QueryResponse<Lot> queryResponse = new QueryResponse<Lot>();
            try
            {
                Lot lot = new Lot();

                lot = lotQuery.GetLot(lotid);

                if (lot != null)
                {
                    queryResponse = QueryResponse<Lot>.Load(lot);
                }                 

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetLot)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchLot(int lotid, LotPatchViewModel lotPatchViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = lotCommand.PatchLot(lotid, lotPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchLot)}");
            }
            return CommandResponse.Load(resultid);
        }

        public QueryResponse<CountModel<Lot>> SearchLot(LotQueryParameters lotQueryParameters)
        {
            QueryResponse<CountModel<Lot>> queryResponse = new QueryResponse<CountModel<Lot>>();
            try
            {

                var list = lotQuery.SearchLot(lotQueryParameters);
                var plist = PagedList<Lot>.ToPagedIList(list, lotQueryParameters.PageNumber, lotQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Lot>>.Load(CountModel<Lot>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(SearchLot)}");
            }
            return queryResponse;
        }

        public CommandResponse UpdateLot(int lotid, LotAddViewModel lotAddViewModel)
        {
            int resultid = 0;
            try
            {
                resultid = lotCommand.UpdateLot(lotid, lotAddViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchLot)}");
            }
            return CommandResponse.Load(resultid);
        }
    }
}
