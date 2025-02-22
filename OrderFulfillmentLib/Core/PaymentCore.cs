
using Common.Model;
using Common.Response;
using Microsoft.Extensions.Logging;
using OrderFulfillmentLib.Core.Abstract;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.Repo.Abstract;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Core
{
    public class PaymentCore : IPaymentCore
    {
        IPaymentCommand PaymentCommand;
        IPaymentQuery PaymentQuery;
        ILogger<PaymentCore> logger;
        public PaymentCore(IPaymentCommand PaymentCommand, IPaymentQuery PaymentQuery, ILogger<PaymentCore> logger)
        {
            this.PaymentQuery = PaymentQuery;
            this.logger = logger;
            this.PaymentCommand = PaymentCommand;

        }
        public CommandResponse AddPayment(PaymentAddViewModel PaymentAddViewModel)
        {
            int result = 0;
            try
            {
                result = PaymentCommand.AddPayment(new Payment
                {
                    amount = PaymentAddViewModel.amount,
                    payment_date = PaymentAddViewModel.payment_date,
                    payment_ref = PaymentAddViewModel.payment_ref,
                    payment_status = PaymentAddViewModel.payment_status,
                    payment_type = PaymentAddViewModel.payment_type,
                    provider_id = PaymentAddViewModel.provider_id,                   
                    order_id = PaymentAddViewModel.order_id
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(AddPayment)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse DeletePayment(int Paymentid)
        {
            bool result = false;
            try
            {
                result = PaymentCommand.DeletePayment(Paymentid);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(DeletePayment)}");
            }
            return CommandResponse.Load(result);
        }

        public QueryResponse<Payment> GetPayment(int Paymentid)
        {
            QueryResponse<Payment> queryResponse = new QueryResponse<Payment>();
            try
            {
                Payment Payment = new Payment();
                if (Paymentid != null)
                {
                    Payment = PaymentQuery.GetPayment(Paymentid);
                    queryResponse = QueryResponse<Payment>.Load(Payment);
                }


            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetPayment)}");
            }


            return queryResponse;
        }

        public QueryResponse<CountModel<Payment>> GetPayments(PaymentQueryParameter PaymentQueryParameters)
        {
            QueryResponse<CountModel<Payment>> queryResponse = new QueryResponse<CountModel<Payment>>();
            try
            {

                var list = PaymentQuery.SearchPayment(PaymentQueryParameters);
                var plist = PagedList<Payment>.ToPagedIList(list, PaymentQueryParameters.PageNumber, PaymentQueryParameters.PageSize);
                queryResponse = QueryResponse<CountModel<Payment>>.Load(CountModel<Payment>.Load(plist));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(GetPayments)}");
            }
            return queryResponse;
        }

        public CommandResponse PatchPayment(int Paymentid, PaymentPatchViewModel PaymentPatchViewModel)
        {
            int result = 0;
            try
            {
                result = PaymentCommand.PatchPayment(Paymentid, PaymentPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchPayment)}");
            }
            return CommandResponse.Load(result);
        }

        public CommandResponse UpdatePayment(int Paymentid, PaymentPatchViewModel PaymentPatchViewModel)
        {
            int result = 0;
            try
            {
                result = PaymentCommand.PatchPayment(Paymentid, PaymentPatchViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error from {nameof(PatchPayment)}");
            }
            return CommandResponse.Load(result);
        }
    }
}
