using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Repo.Query
{
    public class PaymentQuery : IPaymentQuery
    {
        OrderFulfillmentDbContext context;
        ILogger<PaymentQuery> logger;

        public PaymentQuery(OrderFulfillmentDbContext context,
        ILogger<PaymentQuery> logger)
        {
            this.context = context;
            this.logger = logger;

        }
        public Payment GetPayment(int id)
        {
            Payment payment = new Payment();
            try
            {
                var query = context.payments.Find(id);
                if (query == null)
                {
                    payment = null;
                }
                else
                {
                    payment = query;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return payment;
        }

        public List<Payment> SearchPayment(PaymentQueryParameter paymentQueryParameter)
        {
            List<Payment> payments = new List<Payment>();
            try
            {
                var query = context.payments.AsQueryable();
                query = query.Where(a => a.status == 1);
                if (paymentQueryParameter.provider_id != null)
                {
                    query = query.Where(a => a.provider_id == paymentQueryParameter.provider_id);
                }
                if (paymentQueryParameter.order_id != null)
                {
                    query = query.Where(a => a.order_id == paymentQueryParameter.order_id);
                }
                if (paymentQueryParameter.payment_ref != null)
                {
                    query = query.Where(a => a.payment_ref == paymentQueryParameter.payment_ref);
                }
                if (paymentQueryParameter.fromamount != null)
                {
                    query = query.Where(a => a.amount >= paymentQueryParameter.fromamount);
                }
                if (paymentQueryParameter.toamount != null)
                {
                    query = query.Where(a => a.amount <= paymentQueryParameter.toamount);
                }

                if (paymentQueryParameter.dtcreatedfrom != null)
                {
                    query = query.Where(a => a.dt_crtd >= paymentQueryParameter.dtcreatedfrom);
                }
                if (paymentQueryParameter.dtcreatedto != null)
                {
                    query = query.Where(a => a.dt_crtd <= paymentQueryParameter.dtcreatedto);
                }
                if (paymentQueryParameter.from_payment_date != null)
                {
                    query = query.Where(a => a.payment_date >= paymentQueryParameter.from_payment_date);
                }
                if (paymentQueryParameter.to_payment_date != null)
                {
                    query = query.Where(a => a.payment_date <= paymentQueryParameter.to_payment_date);
                }
                if (paymentQueryParameter.payment_type != null)
                {
                    query = query.Where(a => a.payment_type == paymentQueryParameter.payment_type);
                }


                if (query.Count() > 0)
                {
                    payments = query.OrderBy(b => b.id)
                    .Skip((paymentQueryParameter.PageNumber - 1) * paymentQueryParameter.PageSize)
                                            .Take(paymentQueryParameter.PageSize).Select(a => new Payment
                                            {
                                                dt_crtd = a.dt_crtd,
                                                id = a.id,
                                                order_id = a.order_id,
                                                amount = a.amount,  
                                                payment_date = a.payment_date,
                                                payment_type = a.payment_type,
                                                payment_ref = a.payment_ref,
                                                payment_status = a.payment_status,
                                                provider_id = a.provider_id,
                                                uniqueid = a.uniqueid,                                             
                                                status = a.status,
                                                dt_modf = a.dt_modf

                                            }).ToList();

                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.ToString());
            }
            return payments;
        }
    }
}
