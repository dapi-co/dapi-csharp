using Dapi.Types;
using Newtonsoft.Json;

namespace Dapi.Response {
    public class GetACHPullResponse : BaseResponse {

        /// <summary>
        /// This is used only to automate the deserialization of the get response.
        /// This is a private constructor to this lib.
        /// </summary>
        [JsonConstructor]
        internal GetACHPullResponse(string reference, APIStatus status, bool success, string operationID) :
            base(status, success, operationID, null, "", "") {
        }

        /// <summary>
        /// This is used to construct an error response from the reading of the got response.
        /// This is a private constructor to this lib.
        /// </summary>
        internal GetACHPullResponse(string errType, string errMsg) : base(errType, errMsg) {
        }
    }
}
