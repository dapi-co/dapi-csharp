using Dapi.Types;
using Newtonsoft.Json;

namespace Dapi.Response {
    public class GetBeneficiariesResponse : BaseResponse {
        public Beneficiary[] beneficiaries { get; }

        /// <summary>
        /// This is used only to automate the deserialization of the got response.
        /// This is a private constructor to this lib.
        /// </summary>
        [JsonConstructor]
        internal GetBeneficiariesResponse(Beneficiary[] beneficiaries, APIStatus status, bool success, string operationID, UserInput[] userInputs, string type, string msg) :
            base(status, success, operationID, userInputs, type, msg) {
            this.beneficiaries = beneficiaries;
        }

        /// <summary>
        /// This is used to construct an error response from the reading of the got response.
        /// This is a private constructor to this lib.
        /// </summary>
        internal GetBeneficiariesResponse(string errType, string errMsg) : base(errType, errMsg) {
        }
    }
}
