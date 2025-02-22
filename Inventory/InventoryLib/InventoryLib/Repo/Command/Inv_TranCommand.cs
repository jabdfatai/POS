using InventoryLib.Model;
using InventoryLib.Repo.Abstract;
using InventoryLib.Server;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib.Repo.Command
{
    public class Inv_TranCommand : IInv_TranCommand
    {
        InventoryDbContext context;
        ILogger<Inv_TranCommand> logger;
        int resultid = 0;
        public Inv_TranCommand(InventoryDbContext context, ILogger<Inv_TranCommand> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public int AddInvTran(Inv_TransAddViewModel inv_TransAddViewModel)
        {
            try
            {
                context.Inv_Trans.Add(new Inv_Tran
                {
                    dir = inv_TransAddViewModel.dir,
                    dt_crtd = DateTime.Now,
                    inv_stock_id = inv_TransAddViewModel.inv_stock_id,
                    lot_id = inv_TransAddViewModel.lot_id,
                    note = inv_TransAddViewModel.note,
                    qty = inv_TransAddViewModel.qty.Value
                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(AddInvTran), ex.Message);
            }
            return resultid;
        }


        public bool DeleteInvTran(int inv_Tranid)
        {
            bool deletestatus = false;
            try
            {
                var seltranrec = context.Inv_Trans.Find(inv_Tranid);
                seltranrec.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
            return deletestatus;
        }
        public int PatchInvTran(int inv_Tranid, Inv_TransPatchViewModel inv_TransPatchViewModel)
        {
            try
            {
                var seltranrec = context.Inv_Trans.Find(inv_Tranid);

                if (inv_TransPatchViewModel.qty != null)
                {
                    seltranrec.qty = inv_TransPatchViewModel.qty.Value;
                }
                if (inv_TransPatchViewModel.lot_id != null)
                {
                    seltranrec.lot_id = inv_TransPatchViewModel.lot_id.Value;
                }
                if (!string.IsNullOrEmpty(inv_TransPatchViewModel.note))
                {
                    seltranrec.note = inv_TransPatchViewModel.note;
                }


                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
            return resultid;
        }

        public int UpdateInvTran(int inv_Tranid, Inv_TransAddViewModel inv_TransAddViewModel)
        {
            try
            {
                var seltranrec = context.Inv_Trans.Find(inv_Tranid);
                if (seltranrec != null)
                {
                    seltranrec.qty = inv_TransAddViewModel.qty.Value;
                    seltranrec.lot_id = inv_TransAddViewModel.lot_id;
                    seltranrec.note = inv_TransAddViewModel.note;
                }             
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
            return resultid;
        }
    }
}
