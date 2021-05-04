using System.Collections.Generic;
using Dapi.Response;
using Dapi.Types;

namespace Dapi.Products {
    public class Metadata {
        private string appSecret { get; }

        public Metadata(string appSecret) {
            this.appSecret = appSecret;
        }

        public GetAccountsMetadataResponse getAccountsMetadata(string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new GetAccountsMetadataRequest(appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<GetAccountsMetadataRequest, GetAccountsMetadataResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new GetAccountsMetadataResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        private class GetAccountsMetadataRequest : DapiRequest.BaseRequest {
            internal string action => "/metadata/accounts/get";

            public GetAccountsMetadataRequest(string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
            }
        }
    }
}
