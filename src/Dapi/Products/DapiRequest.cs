using System.Collections.Generic;
using Dapi.Types;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Dapi.Products {
    public class DapiRequest {
        public static readonly string Dapi_URL = "https://api.dapi.com";
        public static readonly string DD_URL = "https://dd.dapi.com";
        private static readonly string Library = "dapi-csharp";
        private static readonly string LibraryVersion = "1.3.0";

        internal static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        };

        private static readonly IRestClient httpClient = new RestClient()
            .UseNewtonsoftJson(jsonSettings);

        internal static IRestResponse HandleSDK(object reqBody, ICollection<KeyValuePair<string, string>> headers) {
            // create the request with the passed body and headers
            var req = new RestRequest(DD_URL)
                .AddJsonBody(reqBody)
                .AddHeaders(headers)
                .AddHeader("Host", "dd.dapi.com")
                .AddHeader("X-Dapi-Library", Library)
                .AddHeader("X-Dapi-Library-Version", LibraryVersion);

            httpClient.Timeout = 300000;
            // execute the request and return the raw response type
            return httpClient.Execute(req, Method.POST);
        }

        internal static ResT Do<ReqT, ResT>(ReqT reqBody, string url) {
            return Do<ReqT, ResT>(reqBody, url, new List<KeyValuePair<string, string>>());
        }

        internal static ResT Do<ReqT, ResT>(ReqT reqBody, string action, ICollection<KeyValuePair<string, string>> headers) {
            // create, execute the request, and get the response
            var url = Dapi_URL + "/v2" + action;
            var resp = doReq(reqBody, url, headers);

            // convert the got response body to the required type
            var data = JsonConvert.DeserializeObject<ResT>(resp.Content, jsonSettings);

            // return the data if it's valid, otherwise return an error response
            return data;
        }

        private static IRestResponse doReq<ReqT>(ReqT reqBody, string url, ICollection<KeyValuePair<string, string>> headers) {
            // create the request with the passed body and headers
            var req = new RestRequest(url)
                .AddJsonBody(reqBody)
                .AddHeaders(headers)
                .AddHeader("X-Dapi-Library", Library)
                .AddHeader("X-Dapi-Library-Version", LibraryVersion);

            httpClient.Timeout = 300000;
            // execute the request and return the raw response type
            return httpClient.Execute(req, Method.POST);
        }

        public class BaseRequest {
            public string appSecret { get; }
            public string userSecret { get; }
            public string operationID { get; }
            public UserInput[] userInputs { get; }

            public BaseRequest(string appSecret, string userSecret, string operationID, UserInput[] userInputs) {
                this.appSecret = appSecret;
                this.userSecret = userSecret;
                this.operationID = operationID;
                this.userInputs = userInputs;
            }
        }
    }
}
