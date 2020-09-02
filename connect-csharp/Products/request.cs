using System;
using RestSharp;

namespace TestCsharplibrary.Products
{
    public class request
    {

        private string LIBRARY_USER_AGENT = "Dapi Connect CSharp";
        private string API_HOST = "http://localhost:443";
        private string API_VERSION = "/v1";
        private string contentType = "application/json";
        private RestClient client;


        public request(RestClient client)
        {
            this.client = client;

        }

        public string Request(string path, object dataObj)
        {


            //client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", accessToken));

            var request = new RestRequest(path, Method.POST);

            request.AddJsonBody(dataObj);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return content;

        }

        public string authenticatedRequest(string path, object dataObj, string accessToken)
        {

            client = new RestClient(API_HOST + API_VERSION);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", accessToken));
            client.UserAgent = LIBRARY_USER_AGENT;
            var request = new RestRequest(path, Method.POST);

            request.AddJsonBody(dataObj);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return content;

        }
    }
}
