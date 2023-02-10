using System.Collections.Generic;
using Dapi.Response;
using Dapi.Types;

namespace Dapi.Products {
    public class ACH {
        private string appSecret { get; }

        public ACH(string appSecret) {
            this.appSecret = appSecret;
        }

        public CreateACHPullResponse createACHPull(ACHPull transfer, string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new CreateACHPullRequest(transfer, appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<CreateACHPullRequest, CreateACHPullResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new CreateACHPullResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        public GetACHPullResponse getACHPull(string accessToken, string userSecret, string operationID, UserInput[] userInputs) {
            // Create the request body of this call
            var reqBody = new GetACHPullRequest(appSecret, userSecret, operationID, userInputs);

            // Construct the headers needed for this request
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + accessToken));

            // Make the request and get the response
            var respBody = DapiRequest.Do<GetACHPullRequest, GetACHPullResponse>(reqBody, reqBody.action, headers);

            // return the data if it's valid, otherwise return an error response
            return respBody ?? new GetACHPullResponse("UNEXPECTED_RESPONSE", "Unexpected response body");
        }

        public class ACHPull {
            public string senderID { get; }
            public float amount { get; }
            public string description { get; }

            /// <summary>
            /// Create an object that holds the info for a transfer from a bank that requires the receiver to be already
            /// registered as a beneficiary to perform a transaction.
            /// </summary>
            ///
            /// <param name="senderID">
            /// the id of the account which the money should be sent from.
            /// retrieved from one of the accounts array returned from the getAccounts method.
            /// </param>
            /// <param name="amount">
            /// the amount of money which should be sent.
            /// </param>
            /// <param name="description">
            /// the id of the beneficiary which the money should be sent to.
            /// retrieved from one of the beneficiaries array returned from the getBeneficiaries method.
            /// </param>
            public ACHPull(string senderID, float amount, string description) {
                this.senderID = senderID;
                this.amount = amount;
                this.description = description;
            }
        }

        private class CreateACHPullRequest : DapiRequest.BaseRequest {
            internal string action => "/ach/pull/create";

            public string senderID { get; }
            public float amount { get; }
            public string description { get; }

            public CreateACHPullRequest(ACHPull transfer, string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
                this.senderID = transfer.senderID;
                this.amount = transfer.amount;
                this.description = transfer.description;
            }
        }

        private class GetACHPullRequest : DapiRequest.BaseRequest {
            internal string action => "/ach/pull/get";

            public GetACHPullRequest(string appSecret, string userSecret, string operationID, UserInput[] userInputs) :
                base(appSecret, userSecret, operationID, userInputs) {
            }
        }
    }
}
