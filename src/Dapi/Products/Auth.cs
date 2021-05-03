using Dapi.Response;

namespace Dapi.Products {
    public class Auth {
        private string appSecret { get; }

        public Auth(string appSecret) {
            this.appSecret = appSecret;
        }
        
        public ExchangeTokenResponse exchangeToken(string accessCode, string connectionID) {
            // Create the request body of this call
            var reqBody = new ExchangeTokenRequest(appSecret, accessCode, connectionID);

            // Make the request and get the response
            var respBody = DapiRequest.Do<ExchangeTokenRequest, ExchangeTokenResponse>(reqBody, reqBody.action);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new ExchangeTokenResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        private class ExchangeTokenRequest {
            internal string action => "/auth/ExchangeToken";
            public string appSecret { get; }
            public string accessCode { get; }
            public string connectionID { get; }

            public ExchangeTokenRequest(string appSecret, string accessCode, string connectionID) {
                this.appSecret = appSecret;
                this.accessCode = accessCode;
                this.connectionID = connectionID;
            }
        }
    }
}
