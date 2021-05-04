using Dapi.Types;
using Newtonsoft.Json;

namespace Dapi.Response {
    public class ExchangeTokenResponse : BaseResponse {
        public string accessToken { get; }
        public string tokenID { get; }
        public string userID { get; }

        /// <summary>
        /// This is used only to automate the deserialization of the got response.
        /// This is a private constructor to this lib.
        /// </summary>
        [JsonConstructor]
        internal ExchangeTokenResponse(string accessToken, string tokenID, string userID, APIStatus status, bool success, string operationID, UserInput[] userInputs, string type, string msg) :
            base(status, success, operationID, userInputs, type, msg) {
            this.accessToken = accessToken;
            this.tokenID = tokenID;
            this.userID = userID;
        }

        /// <summary>
        /// This is used to construct an error response from the reading of the got response.
        /// This is a private constructor to this lib.
        /// </summary>
        internal ExchangeTokenResponse(string errType, string errMsg) : base(errType, errMsg) {
        }
    }
}
