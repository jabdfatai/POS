using OrderFulfillmentLib.Model;
using OrderFulfillmentLib.QueryParameters;
using OrderFulfillmentLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFulfillmentLib.Repo.Abstract
{
    public interface IPaymentCommand
    {
        int AddPayment(Payment payment);
        int PatchPayment(int id, PaymentPatchViewModel paymentPatchViewModel);
        bool DeletePayment(int id);
    }
    public interface IPaymentQuery
    {
        List<Payment> SearchPayment(PaymentQueryParameter paymentQueryParameter);
        Payment GetPayment(int id);
    }
}
