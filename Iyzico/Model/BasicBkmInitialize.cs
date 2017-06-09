﻿using Iyzipay.Request;
using System;

namespace Iyzipay.Model
{
    public class BasicBkmInitialize : IyzipayResource
    {
        public String HtmlContent { get; set; }
        public String Token { get; set; }
        
        public static BasicBkmInitialize Create(CreateBasicBkmInitializeRequest request, Options options)
        {
            BasicBkmInitialize response = RestHttpClient.Create().Post<BasicBkmInitialize>(options.BaseUrl + "/payment/bkm/initialize/basic", request, options);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.decodeString(response.HtmlContent);
            }
            return response;
        }
    }
}
