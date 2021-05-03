using System;
using System.Collections.Generic;
using Dapi.Response;
using Dapi.Types;

namespace Dapi.Products {
    public class Data {
        private string appSecret { get; }

        public Data(string appSecret) {
            this.appSecret = appSecret;
        }

        public GetIdentityResponse getIdentity(string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new GetIdentityRequest(appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<GetIdentityRequest, GetIdentityResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new GetIdentityResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        public GetAccountsResponse getAccounts(string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new GetAccountsRequest(appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<GetAccountsRequest, GetAccountsResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new GetAccountsResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        public GetBalanceResponse getBalance(string accountID, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new GetBalanceRequest(accountID, appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<GetBalanceRequest, GetBalanceResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new GetBalanceResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        public GetTransactionsResponse getTransactions(string accountID, DateTime fromDate, DateTime toDate, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new GetTransactionsRequest(accountID, fromDate, toDate, appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<GetTransactionsRequest, GetTransactionsResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new GetTransactionsResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        private class GetIdentityRequest : DapiRequest.BaseRequest {
            internal string action => "/data/identity/get";

            public GetIdentityRequest(string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
            }
        }

        private class GetAccountsRequest : DapiRequest.BaseRequest {
            internal string action => "/data/accounts/get";

            public GetAccountsRequest(string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
            }
        }

        private class GetBalanceRequest : DapiRequest.BaseRequest {
            internal string action => "/data/balance/get";
            public string accountID { get; }

            public GetBalanceRequest(string accountID, string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
                this.accountID = accountID;
            }
        }

        private class GetTransactionsRequest : DapiRequest.BaseRequest {
            internal string action => "/data/transactions/get";
            public string accountID { get; }
            public string fromDate { get; }
            public string toDate { get; }

            private readonly string dateFormat = "yyyy-MM-dd";

            public GetTransactionsRequest(string accountID, DateTime fromDate, DateTime toDate, string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
                this.accountID = accountID;
                this.fromDate = fromDate.ToString(dateFormat);
                this.toDate = toDate.ToString(dateFormat);
            }
        }
    }
}
