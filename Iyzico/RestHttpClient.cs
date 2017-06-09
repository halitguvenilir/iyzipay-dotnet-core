using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Iyzipay
{
    public class RestHttpClient : IyzipayResource
    {
        private static readonly String AUTHORIZATION = "Authorization";
        private static readonly String RANDOM_HEADER_NAME = "x-iyzi-rnd";
        private static readonly String CLIENT_VERSION = "x-iyzi-client-version";
        private static readonly String IYZIWS_HEADER_NAME = "IYZWS ";
        private static readonly String COLON = ":";

        public static RestHttpClient Create()
        {
            return new RestHttpClient();
        }

        private static String PrepareAuthorizationString(BaseRequest request, String randomString, Options options)
        {
            String hash = HashGenerator.generateHash(options.ApiKey, options.SecretKey, randomString, request);
            return IYZIWS_HEADER_NAME + options.ApiKey + COLON + hash;
        }

        public T Get<T>(String url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(url).Result;

            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        public T Post<T>(String url, BaseRequest request, Options options)
        {
            HttpClient httpClient = new HttpClient();

            string randomString = DateTime.Now.ToString("ddMMyyyyhhmmssffff");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add(RANDOM_HEADER_NAME, randomString);
            httpClient.DefaultRequestHeaders.Add(CLIENT_VERSION, "iyzipay-dotnet-2.1.9");
            httpClient.DefaultRequestHeaders.Add(AUTHORIZATION, PrepareAuthorizationString(request, randomString, options));

            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, JsonBuilder.ToJsonString(request)).Result;
            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        public T Delete<T>(String url, BaseRequest request, Options options)
        {
            HttpClient httpClient = new HttpClient();
            string randomString = DateTime.Now.ToString("ddMMyyyyhhmmssffff");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add(RANDOM_HEADER_NAME, randomString);
            httpClient.DefaultRequestHeaders.Add(CLIENT_VERSION, "iyzipay-dotnet-2.1.9");
            httpClient.DefaultRequestHeaders.Add(AUTHORIZATION, PrepareAuthorizationString(request, randomString, options));
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Content = JsonBuilder.ToJsonString(request),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url)

            };
            HttpResponseMessage httpResponseMessage = httpClient.SendAsync(requestMessage).Result;
            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        public T Put<T>(String url, BaseRequest request, Options options)
        {
            HttpClient httpClient = new HttpClient();
            string randomString = DateTime.Now.ToString("ddMMyyyyhhmmssffff");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add(RANDOM_HEADER_NAME, randomString);
            httpClient.DefaultRequestHeaders.Add(CLIENT_VERSION, "iyzipay-dotnet-2.1.9");
            httpClient.DefaultRequestHeaders.Add(AUTHORIZATION, PrepareAuthorizationString(request, randomString, options));
            HttpResponseMessage httpResponseMessage = httpClient.PutAsync(url, JsonBuilder.ToJsonString(request)).Result;
            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }
    }
}
