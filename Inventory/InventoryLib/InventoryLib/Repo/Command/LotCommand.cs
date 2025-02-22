using InventoryLib.Model;
using InventoryLib.Repo.Abstract;
using InventoryLib.Server;
using InventoryLib.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLib.Repo.Command
{
    public class LotCommand : IlotCommand
    {
        InventoryDbContext context;
        ILogger<LotCommand> logger;
        int resultid = 0;

        public LotCommand(InventoryDbContext context, ILogger<LotCommand> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public int AddLot(LotAddViewModel lotAddViewModel)
        {
            try
            {
                context.Lots.Add(new Lot
                {
                    batch_no = lotAddViewModel.batch_no,
                    descr = lotAddViewModel.descr,
                    exp_date = lotAddViewModel.exp_time,
                    lotno = lotAddViewModel.lotno,
                    manf_date = lotAddViewModel.manf_date,
                    prod_id = lotAddViewModel.prod_id,
                    pur_ord_id = lotAddViewModel.pur_ord_id,
                    qty = lotAddViewModel.qty,
                    vend_id = lotAddViewModel.vend_id


                });
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;
        }

        public bool DeleteLot(int lotid)
        {
            bool deletestatus = false;
            try
            {

                var seltranrec = context.Lots.Find(lotid);
                seltranrec.status = 0;
                resultid = context.SaveChanges();
                deletestatus = resultid > 0 ? true : false;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return deletestatus;
        }

        //public int PatchLot(int lotid, LotPatchViewModel lotPatchViewModel)
        //{
          
        //    try
        //    {
        //        var seluserevent = context.Lots.FirstOrDefault(a => a.id == lotid);
        //        if (seluserevent != null)
        //        {

        //            string filter = $" where id = {lotid}";

        //            var patchquery = GetPatchString("Lots", lotPatchViewModel);
        //            var res = context.Database.ExecuteSqlRaw(patchquery + filter);
        //            resultid = context.SaveChanges();
                    

        //        }

               
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex.ToString(), ex);

        //    }
        //    return resultid;
        //}

        string GetPatchString(string tablename, LotPatchViewModel lotPatchViewModel)
        {
            string query = $"update {tablename} set ";
            string delim = "";

            PropertyInfo[] pi = lotPatchViewModel.GetType().GetProperties();
            for (int i = 0; i < pi.Length; i++)
            {
                if (pi[i].CanRead)
                {
                    {
                        if (pi[i].GetValue(lotPatchViewModel) != null)
                        {

                            query = query + delim + pi[i].Name + " = '" + EscapeData(pi[i].GetValue(lotPatchViewModel).ToString()) + "'";
                            delim = ",";
                        }
                    }

                }
            }

            return query;

        }

        protected object EscapeData(object myData)
        {
            try
            {
                if (myData == null)
                {
                    return myData;
                }

                if (myData.ToString().IndexOf('\'') >= 0) // .IndexOfAny(.Contains("'")) 
                {
                    return myData.ToString().Replace("'", "''");
                }
                else
                {
                    return myData;
                }
            }
            catch (Exception ex)
            {

                return myData;
            }

        }
        public int PatchLot(int lotid, LotPatchViewModel lotPatchViewModel)
        {
            try
            {
                var seltranrec = context.Lots.Find(lotid);
                if (lotPatchViewModel.exp_time != null)
                {
                    seltranrec.exp_date = lotPatchViewModel.exp_time.Value;
                }
                if (lotPatchViewModel.vend_id != null)
                {
                    seltranrec.vend_id = lotPatchViewModel.vend_id.Value;
                }
                if (lotPatchViewModel.batch_no != null)
                {
                    seltranrec.batch_no = lotPatchViewModel.batch_no;
                }
                if (lotPatchViewModel.descr != null)
                {
                    seltranrec.descr = lotPatchViewModel.descr;
                }
                if (lotPatchViewModel.lotno != null)
                {
                    seltranrec.lotno = lotPatchViewModel.lotno;
                }
                if (lotPatchViewModel.manf_date != null)
                {
                    seltranrec.manf_date = lotPatchViewModel.manf_date.Value;
                }
                if (lotPatchViewModel.prod_id != null)
                {
                    seltranrec.prod_id = lotPatchViewModel.prod_id.Value;
                }
                if (lotPatchViewModel.pur_ord_id != null)
                {
                    seltranrec.pur_ord_id = lotPatchViewModel.pur_ord_id.Value;
                }
                if (lotPatchViewModel.qty != null)
                {
                    seltranrec.qty = lotPatchViewModel.qty.Value;
                }
                seltranrec.dt_modf = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;

        }

        public int UpdateLot(int lotid, LotAddViewModel lotAddViewModel)
        {
            try
            {
                var seltranrec = context.Lots.Find(lotid);
                seltranrec.exp_date = lotAddViewModel.exp_time;
                seltranrec.vend_id = lotAddViewModel.vend_id;
                seltranrec.batch_no = lotAddViewModel.batch_no;
                seltranrec.descr = lotAddViewModel.descr;
                seltranrec.lotno = lotAddViewModel.lotno;
                seltranrec.manf_date = lotAddViewModel.manf_date;
                seltranrec.prod_id = lotAddViewModel.prod_id;
                seltranrec.pur_ord_id = lotAddViewModel.pur_ord_id;
                seltranrec.qty = lotAddViewModel.qty;
                seltranrec.dt_modf = DateTime.UtcNow;
                resultid = context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return resultid;    

        }

        public int PatchLot(int lotid, LotAddViewModel lotAddViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
