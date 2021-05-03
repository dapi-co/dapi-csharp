using Dapi.Types;
using Newtonsoft.Json;

namespace Dapi.Response {
    public class BaseResponse {
        /// <summary>
        /// the status of the operation.
        /// </summary>
        public APIStatus status { get; }
        
        /// <summary>
        /// true if request is successful and false otherwise.
        /// </summary>
        public bool success { get; }

        /// <summary>
        /// a unique ID generated to identify a specific operation.
        /// </summary>
        public string operationID { get; }

        /// <summary>
        /// the UserInputs required for this operation, which are the further information
        /// required from the user before the job can be completed.
        /// </summary>
        public UserInput[] userInputs { get; }

        /// <summary>
        /// the type of error encountered.
        /// only available if the operation was not successful.
        /// </summary>
        public string type { get; }

        /// <summary>
        /// the message of the error encountered.
        /// only available if the operation was not successful.
        /// </summary>
        public string msg { get; }

        /// <summary>
        /// This is used only to automate the deserialization of the got response.
        /// This is a private constructor to this lib.
        /// </summary>
        [JsonConstructor]
        internal BaseResponse(APIStatus status, bool success, string operationID, UserInput[] userInputs, string type, string msg) {
            this.status = status;
            this.success = success;
            this.operationID = operationID;
            this.userInputs = userInputs;
            this.type = type;
            this.msg = msg;
        }

        /// <summary>
        /// This is used to construct an error response from the reading of the got response.
        /// This is a private constructor to this lib.
        /// </summary>
        protected BaseResponse(string errType, string errMsg) {
            this.status = APIStatus.failed;
            this.success = false;
            this.type = errType;
            this.msg = errMsg;
            this.operationID = null;
            this.userInputs = null;
        }
    }
}
