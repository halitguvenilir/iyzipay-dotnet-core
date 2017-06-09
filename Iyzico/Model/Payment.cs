﻿using Iyzipay.Request;

namespace Iyzipay.Model
{
    public class Payment : PaymentResource
    {
        public static Payment Create(CreatePaymentRequest request, Options options)
        {
            return RestHttpClient.Create().Post<Payment>(options.BaseUrl + "/payment/auth", request, options);
        }

        public static Payment Retrieve(RetrievePaymentRequest request, Options options)
        {
            return RestHttpClient.Create().Post<Payment>(options.BaseUrl + "/payment/detail", request, options);
        }
    }
}
