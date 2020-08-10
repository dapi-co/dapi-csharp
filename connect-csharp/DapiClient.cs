using System;
using System.Net.Http;
using connect_csharp.Products;

using RestSharp;

namespace connect_csharp
{
    public class DapiClient
    {

        private string appSecret;

        private String LIBRARY_USER_AGENT = "Dapi Connect CSharp";
        private String API_HOST = "http://localhost:443";
        private String API_VERSION = "/v1";
        private String contentType = "application/json";
        private RestClient client;
        public DapiClient(String appSecret)
        {
            this.appSecret = appSecret;
            client = new RestClient(API_HOST + API_VERSION);

        }




        //*****************************NormalRequest*****************************

        public string Request(string path, object dataObj)
        {


            //client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", accessToken));

            var request = new RestRequest(path, Method.POST);

            request.AddJsonBody(dataObj);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return content;

        }
        //*****************************AuthenticatedRequest*****************************
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
        //*****************************AUTH*****************************

        public string exchangeToken(string appSecret, string accessCode, string connectionId)
        {
            return Request(Auth.GetPathExchangeToken(), Auth.getPostDataExchangeToken(appSecret, accessCode, connectionId));
        }

        public string checkLogin(string appSecret, string userSecret)
        {
            return Request(Auth.getPathCheckLogin(), Auth.getPostDataCheckLogin(appSecret, userSecret));
        }
        public string delinkUser(string appSecret, string accessToken)
        {
            return authenticatedRequest(Auth.getPathDeLinkUser(), Auth.getPostDataDeLinkUser(appSecret), accessToken);
        }

        public string refreshAccessToken(string appSecret, string accessToken)
        {
            return Request(Auth.GetPathRefreshAccessToken(), Auth.getPostDataRefreshAccessToken(appSecret, accessToken));
        }
        //*****************************DATA*****************************
        public string getIdentity(string accessToken, string userSecret)
        {

            return authenticatedRequest(Data.GetPathIdentity(), Data.GetPostDataIdentity(this.appSecret, userSecret), accessToken);
        }

        public string getAccounts(string accessToken, string userSecret)
        {
            return authenticatedRequest(Data.GetPathAccounts(), Data.GetPostDataAccounts(this.appSecret, userSecret), accessToken);
        }

        public string getBalance(string accessToken, string userSecret, string accountID)
        {
            return authenticatedRequest(Data.GetPathBalance(), Data.GetPostDataBalance(this.appSecret, userSecret, accountID), accessToken);
        }
        public string getTransactions(string accessToken, string userSecret, string accountID, string toDate, string fromDate)
        {
            return authenticatedRequest(Data.GetPathTransations(), Data.GetPostDataTransactions(this.appSecret, userSecret, accountID, toDate, fromDate), accessToken);
        }

        public string getMetaData(string accessToken, string userSecret)
        {
            return authenticatedRequest(Data.GetPathMetaData(), Data.GetPostDataMetaData(this.appSecret, userSecret), accessToken);
        }
        //*****************************PAYMENT*****************************

        public string createTransfer(string accessToken, string userSecret, string receiverID, string senderID, string amount)
        {
            return authenticatedRequest(payment.getPathCreateTransfer(), payment.getPostDataCreateTransfer(this.appSecret, userSecret, receiverID, senderID, amount), accessToken);
        }
        public string createBeneficiary(string accessToken, string userSecret, string name, string accountNumber, string type, string address, string bankName, string swiftCode)
        {
            return authenticatedRequest(payment.getPathCreateBeneficiary(), payment.getPostDataCreateBeneficiary(this.appSecret, userSecret, name, accountNumber, type, address, bankName, swiftCode), accessToken);
        }
        public string getBeneficiary(string accessToken, string userSecret)
        {
            return authenticatedRequest(payment.getPathGetBeneficiary(), payment.getPostDataGetBeneficiary(appSecret, userSecret), accessToken);
        }
        //*****************************JOBS*****************************
        public string getJobStatus(string accessToken, string userSecret, string jobID)
        {
            return authenticatedRequest(jobs.getPathJobStatus(), jobs.getPostDataJobStatus(appSecret, userSecret, jobID), accessToken);
        }
    }
}

