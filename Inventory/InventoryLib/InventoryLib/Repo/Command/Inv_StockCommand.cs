using InventoryLib.Model;
using InventoryLib.Repo.Abstract;
using InventoryLib.Server;
using InventoryLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Command
{
    public class Inv_StockCommand : IInv_StockCommand
    {
        InventoryDbContext context;
        int resultid = 0;
        public Inv_StockCommand(InventoryDbContext _context)
        {
            context = _context;
        }
        public int AddInvStock(Inv_StockAddViewModel inv_StockAddViewModel)
        {
            try
            {
                context.Inv_Stocks.Add(new Inv_Stock
                {
                    dt_crtd = DateTime.UtcNow,
                    prod_id = inv_StockAddViewModel.prod_id,
                    qty = inv_StockAddViewModel.qty,
                    SKU = inv_StockAddViewModel.SKU,
                    targ_inv_level = inv_StockAddViewModel.targ_inv_level,
                    uniqueid = Guid.NewGuid()
                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return resultid;

        }

        public bool DeleteStock(int inv_Stockid)
        {
            bool deletestatus = false;
            try
            {
                var selstockrec = context.Inv_Stocks.Find(inv_Stockid);
                selstockrec.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {

            }
            return deletestatus;
        }

        public int PatchInvStock(int inv_Stockid, Inv_StockPatchViewModel inv_StockAddViewModel)
        {
            try
            {
                var selstockrec = context.Inv_Stocks.Find(inv_Stockid);

                if (inv_StockAddViewModel.qty != null )
                {
                    selstockrec.qty = inv_StockAddViewModel.qty.Value;
                }
                if (inv_StockAddViewModel.targ_inv_level != null)
                {
                    selstockrec.targ_inv_level = inv_StockAddViewModel.targ_inv_level.Value;
                }
                if (!string.IsNullOrEmpty(inv_StockAddViewModel.SKU))
                {
                    selstockrec.SKU = inv_StockAddViewModel.SKU;
                }
                
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return resultid;
        }

        public int UpdateInvStock(int inv_Stockid, Inv_StockAddViewModel inv_StockAddViewModel)
        {
            try
            {
                var selstockrec = context.Inv_Stocks.Find(inv_Stockid);
                selstockrec.prod_id = inv_StockAddViewModel.prod_id;
                selstockrec.qty = inv_StockAddViewModel.qty;
                selstockrec.SKU = inv_StockAddViewModel.SKU;
                selstockrec.targ_inv_level = inv_StockAddViewModel.targ_inv_level;
                selstockrec.dt_modf = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return resultid;
        }
    } 
}
