
using Common.Model;
using Common.Response;
using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;

namespace OrderFulfillmentLib.Core.Abstract
{
    public interface IPaymentCore
    {
        public CommandResponse AddPayment(PaymentAddViewModel PaymentAddViewModel);

        public CommandResponse UpdatePayment(int Paymentid, PaymentPatchViewModel PaymentPatchViewModel);
        public CommandResponse PatchPayment(int Paymentid, PaymentPatchViewModel PaymentPatchViewModel);
        public CommandResponse DeletePayment(int Paymentid);

        public QueryResponse<CountModel<Payment>> GetPayments(PaymentQueryParameter PaymentQueryParameters);

        public QueryResponse<Payment> GetPayment(int Paymentid);
    }



}
