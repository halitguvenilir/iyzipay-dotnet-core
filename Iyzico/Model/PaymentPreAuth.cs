using Iyzipay.Request;

namespace Iyzipay.Model
{
    public class PaymentPreAuth : PaymentResource
    {
        public static PaymentPreAuth Create(CreatePaymentRequest request, Options options)
        {
            return RestHttpClient.Create().Post<PaymentPreAuth>(options.BaseUrl + "/payment/preauth", request, options);
        }

        public static PaymentPreAuth Retrieve(RetrievePaymentRequest request, Options options)
        {
            return RestHttpClient.Create().Post<PaymentPreAuth>(options.BaseUrl + "/payment/detail", request, options);
        }
    }
}
