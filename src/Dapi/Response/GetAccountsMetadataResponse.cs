using Dapi.Types;
using Newtonsoft.Json;

namespace Dapi.Response {
    public class GetAccountsMetadataResponse : BaseResponse {
        public AccountsMetadata accountsMetadata { get; }

        /// <summary>
        /// This is used only to automate the deserialization of the got response.
        /// This is a private constructor to this lib.
        /// </summary>
        [JsonConstructor]
        internal GetAccountsMetadataResponse(AccountsMetadata accountsMetadata, APIStatus status, bool success, string operationID, UserInput[] userInputs, string type, string msg) :
            base(status, success, operationID, userInputs, type, msg) {
            this.accountsMetadata = accountsMetadata;
        }

        /// <summary>
        /// This is used to construct an error response from the reading of the got response.
        /// This is a private constructor to this lib.
        /// </summary>
        internal GetAccountsMetadataResponse(string errType, string errMsg) : base(errType, errMsg) {
        }
    }
}
